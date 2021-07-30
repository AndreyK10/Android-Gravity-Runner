using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private float score;
    [SerializeField] private float scorePerSecond;
    public static int intScore { get; private set; }

    void Start()
    {
        score = 0f;
    }

    void Update()
    {
        score += scorePerSecond * Time.deltaTime;
        intScore = (int)score;
        scoreText.text = intScore.ToString();
    }
}
