using UnityEngine;
//CHECK
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    
    // Runs when game starts (i.e. script is loaded)
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    
    // Runs every frame to change player's movement direction
    private void Update()
    {
        // Updates horizontal movement (vertical is kept the same)
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        // Jump when space is pressed
        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);
    }
}
