using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject panneauGameOver;
    public TextMeshProUGUI texteScore;
    private int score = 0;

    void Awake()
    {
        Instance = this;
        Time.timeScale = 1;

        // On s’assure que le panneau Game Over est bien caché au lancement
        if (panneauGameOver != null)
            panneauGameOver.SetActive(false);
    }

    public void AjouterPoints(int nombre)
    {
        score += nombre;
        texteScore.text = "Score : " + score;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        if (panneauGameOver != null)
            panneauGameOver.SetActive(true);
    }

    public void Rejouer()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitterJeu()
    {
        Application.Quit();
    }
}
