using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    private Rigidbody2D body;
    private bool grounded;
    public bool falling;
    
    private void Awake()
    {
        speed = speed + Shop.map["speed"];
        body = GetComponent<Rigidbody2D>();
    }

    // Runs every frame to change player's movement direction
    private void Update()
    {
        // Updates horizontal movement (vertical is kept the same)
        body.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, body.velocity.y);

        // Jump when space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            Jump();

        // Adjust height (jump height varies based on how long Space is held)
        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);

        // Fast fall
        if (Input.GetKeyDown(KeyCode.DownArrow) && body.velocity.y > 0)
            body.velocity = new Vector2(body.velocity.x, -2);
    }
    
    // Jump is based on speed 
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed - 1);
        grounded = false;
    }
    
    // Player collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true; // Prevents mid-air jumps

            // Reorients player so firepoint is always forward when on ground
            if (gameObject.transform.rotation.eulerAngles.z != 0 && collision.gameObject.tag != "Ramp")
            {
                Vector3 reOrient = new Vector3(0, 0, 0);
                gameObject.transform.eulerAngles = reOrient;
            }
        }
        
        // Ramps will launch the player upwards and spins them
        if (collision.gameObject.tag == "Ramp")
        {
            grounded = false;
            body.velocity = new Vector2(body.velocity.x * 2.5f, 3);
            StartCoroutine(Spin());
        }
        
        // Spinning into an enemy will bounce you upward and spins you again
        if (collision.gameObject.tag == "Enemy")
        {
            body.velocity = new Vector2(body.velocity.x, 8);
            StartCoroutine(SpinRebound());
        }

        // Stops spin on obstacles
        if (collision.gameObject.tag == "Obstacle")
        {
            body.freezeRotation = true;
            body.freezeRotation = false;
            Vector3 reOrient = new Vector3(0, 0, 0);
            gameObject.transform.eulerAngles = reOrient;
        }
    }
    
    // Spinning logic
    IEnumerator Spin()
    {
        // Max rotational speed is 30 rads/sec
        if (body.angularVelocity < 30)
        {
            var impulse = 10 + body.inertia;
            yield return new WaitForSeconds(0.5f);
            body.velocity = new Vector2(body.velocity.x, 0);
            body.AddTorque(impulse, ForceMode2D.Impulse);
        }
    }

    IEnumerator SpinRebound()
    {
        // Rebound will only trigger if the player is already spinning when they collide with an enemy
        if (body.angularVelocity < 30 && body.angularVelocity > 1)
        {
            var impulse = 20 + body.inertia;
            yield return new WaitForSeconds(0.25f);
            body.velocity = new Vector2(body.velocity.x, -1);
            body.AddTorque(impulse, ForceMode2D.Impulse);
        }
    }
}