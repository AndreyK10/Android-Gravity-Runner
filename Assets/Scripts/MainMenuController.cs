using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    public TextMeshProUGUI highScoretext;
    public GameObject mainMenuScreen;

    private void Start()
    {
        mainMenuScreen.gameObject.SetActive(true);
        highScoretext.text = "HIGHSCORE: " + PlayerPrefs.GetInt(GameplayController.PREFS_HIGHSCORE);
    }
    public void NewGame()
    {
        Time.timeScale = 1;        
        SceneManager.LoadScene(1);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
    public void DeleteHighScore()
    {
        PlayerPrefs.DeleteAll();
        highScoretext.text = "HIGHSCORE: " + PlayerPrefs.GetInt(GameplayController.PREFS_HIGHSCORE);
    }

    public void PlayButtonSound()
    {
        AudioManager.instance.PlaySound(AudioManager.BUTTON_SOUND);
    }

    public void MuteMusic()
    {
        AudioManager.instance.MuteMusic(AudioManager.BGMUSIC);
    }

    public void MuteSound()
    {
        AudioManager.instance.MuteSound(AudioManager.BUTTON_SOUND, AudioManager.GAME_OVER_SOUND, AudioManager.JUMP_SOUND);
    }

}
