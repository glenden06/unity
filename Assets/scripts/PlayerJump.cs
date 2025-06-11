using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 10f; // Force applied when the player jumps
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    public LayerMask groundLayer; // Layer mask to identify ground objects
    private bool isGrounded; // Flag to check if the player is on the ground
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.1f, groundLayer); // Check if the player is on the ground
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) // Check if the player is on the ground and the jump button is pressed
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Apply an upward force to the player
        }
    }
}
