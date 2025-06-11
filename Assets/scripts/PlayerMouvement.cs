using UnityEngine;

public class PlayerMouvement: MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    private Rigidbody2D rb; // Reference to the Rigidbody2D component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal"); // Get horizontal input (A/D or Left/Right arrow keys)
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y); // Move the player horizontally
    }
}
