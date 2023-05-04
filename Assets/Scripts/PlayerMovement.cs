using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    private Rigidbody2D body;
    private bool grounded;
    public bool falling;
    //float falltime = 5F;
    //float MaxFallTime = 10.0F;

    // Runs when game starts (i.e. script is loaded)
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

        // Adjust height
        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);

        // Fast fall
        if (Input.GetKeyDown(KeyCode.DownArrow) && body.velocity.y > 0)
            body.velocity = new Vector2(body.velocity.x, -2);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed - 1);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;

            // Reorients player so firepoint is always forward when on ground
            if (gameObject.transform.rotation.eulerAngles.z != 0 && collision.gameObject.tag != "Ramp")
            {
                Vector3 reOrient = new Vector3(0, 0, 0);
                gameObject.transform.eulerAngles = reOrient;
            }
        }

        if (collision.gameObject.tag == "Ramp")
        {
            grounded = false;
            body.velocity = new Vector2(body.velocity.x * 2.5f, 3);
            StartCoroutine(Spin());
        }

        if (collision.gameObject.tag == "Enemy")
        {
            body.velocity = new Vector2(body.velocity.x, 8);
            StartCoroutine(SpinRebound());
        }

        // Temporarily stops spin on obstacles
        if (collision.gameObject.tag == "Obstacle")
        {
            body.freezeRotation = true;
            body.freezeRotation = false;
            Vector3 reOrient = new Vector3(0, 0, 0);
            gameObject.transform.eulerAngles = reOrient;
        }
    }

    IEnumerator Spin()
    {
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
        if (body.angularVelocity < 30 && body.angularVelocity > 1)
        {
            var impulse = 20 + body.inertia;
            yield return new WaitForSeconds(0.25f);
            body.velocity = new Vector2(body.velocity.x, -1);
            body.AddTorque(impulse, ForceMode2D.Impulse);
        }
    }
}