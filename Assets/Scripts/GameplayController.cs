using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameplayController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText, gameOverScoreText, highScoreText;
    [SerializeField] private Button pauseButton, jumpButton;
    [SerializeField] private GameObject pauseScreen, gameOverScreen;

    public const string PREFS_HIGHSCORE = "HS_v1.0";

    public static bool isPaused { get; private set; }

    private void Start()
    {
        isPaused = false;
    }

    private void Update()
    {
        if (PlayerController.isDead)
        {
            GameOver();
            PlayerController.isDead = false;
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        pauseButton.gameObject.SetActive(false);
        pauseScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseButton.gameObject.SetActive(true);
        pauseScreen.SetActive(false);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        jumpButton.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        gameOverScoreText.text = ScoreManager.intScore.ToString();
        if (ScoreManager.intScore > PlayerPrefs.GetInt(PREFS_HIGHSCORE))
        {
            PlayerPrefs.SetInt(PREFS_HIGHSCORE, ScoreManager.intScore);
            highScoreText.text = "HIGHSCORE: " + ScoreManager.intScore;
        }
        else
        {
            highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt(PREFS_HIGHSCORE);
        }
    }
}

