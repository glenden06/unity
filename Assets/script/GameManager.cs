using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI")]
    [SerializeField] private Text texteScore;
    [SerializeField] private GameObject panelGameOver;

    private int score = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        Time.timeScale = 1;
        panelGameOver.SetActive(false);
    }

    public void AjouterPoints(int points)
    {
        score += points;
        texteScore.text = score.ToString();
    }

    public void FinDeJeu()
    {
        Time.timeScale = 0;
        panelGameOver.SetActive(true);
    }

    public void Rejouer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quitter()
    {
        Application.Quit();
    }
}