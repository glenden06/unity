using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float vitesse = 5f;         // Vitesse horizontale
    public float forceSaut = 7f;       // Force du saut
    private Rigidbody2D rb;
    private bool estAuSol = false;     // Est-ce que le joueur est sur le sol ?

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Déplacement horizontal
        float mouvement = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(mouvement * vitesse, rb.linearVelocity.y);

        // Saut
        if (Input.GetButtonDown("Jump") && estAuSol)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forceSaut);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si le joueur touche un objet avec le tag "sol"
        if (collision.gameObject.CompareTag("sol"))
        {
            estAuSol = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Si le joueur quitte le contact avec un objet tagué "sol"
        if (collision.gameObject.CompareTag("sol"))
        {
            estAuSol = false;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
