using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameplayController : MonoBehaviour
{
    public TextMeshProUGUI scoreText, gameOverScoreText, highScoreText;
    public Button pauseButton;
    public GameObject pauseScreen, gameOverScreen;

    public const string PREFS_HIGHSCORE = "HS_v1.0";
        

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
        pauseButton.gameObject.SetActive(false);
        pauseScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
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

