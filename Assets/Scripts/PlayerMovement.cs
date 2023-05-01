using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    private Rigidbody2D body;
    private bool grounded;
    public bool falling;
    float falltime = 5F;
    float MaxFallTime = 10.0F;

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
        if (grounded)
        {
            falling = true;
        }
        else
        {
            falling = false;
        }
        if (falling)
        {

            falltime += Time.deltaTime;
            if (falltime >= MaxFallTime)
            {
                SceneManager.LoadScene("Level1");
            }
        }

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
        }

        if (collision.gameObject.tag == "Ramp")
        {
            body.velocity = new Vector2(body.velocity.x * 1.25f, 3);
            StartCoroutine(Spin());
        }

        if (collision.gameObject.tag == "Enemy")
        {
            body.velocity = new Vector2(body.velocity.x, 8);
            StartCoroutine(SpinRebound());
        }
    }

    IEnumerator Spin()
    {
        if (body.angularVelocity < 15)
        {
            var impulse = 5 + body.inertia;
            yield return new WaitForSeconds(0.25f);
            body.velocity = new Vector2(body.velocity.x, 0);
            body.AddTorque(impulse, ForceMode2D.Impulse);
        }
    }

    IEnumerator SpinRebound()
    {
        if (body.angularVelocity < 15 && body.angularVelocity > 1)
        {
            var impulse = 20 + body.inertia;
            yield return new WaitForSeconds(0.25f);
            body.velocity = new Vector2(body.velocity.x, -1);
            body.AddTorque(impulse, ForceMode2D.Impulse);
        }
    }
}