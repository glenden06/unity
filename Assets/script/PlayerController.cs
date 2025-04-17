using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Paramètres")]
    [SerializeField] private float vitesse = 8f;
    [SerializeField] private float forceSaut = 12f;
    [SerializeField] private PhysicsMaterial2D matSansFriction;

    private Rigidbody2D rb;
    private bool peutSauter = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.sharedMaterial = matSansFriction;
    }

    private void Update()
    {
        float input = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(input * vitesse, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && peutSauter)
        {
            rb.AddForce(Vector2.up * forceSaut, ForceMode2D.Impulse);
            peutSauter = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sol"))
        {
            peutSauter = true;
        }
    }
}