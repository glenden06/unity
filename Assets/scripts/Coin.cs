using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip sonCollecte;
    [SerializeField] private int valeur = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(sonCollecte, transform.position);
            GameManager.Instance.AjouterPoints(valeur);
            Destroy(gameObject);
        }
    }
}
