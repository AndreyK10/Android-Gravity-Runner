using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private float score;
    [SerializeField] private float scorePerSecond;
    public static int intScore { get; private set; }

    private void Start()
    {
        score = 0f;
    }

    private void Update()
    {
        score += scorePerSecond * Time.deltaTime;
        intScore = (int)score;
        scoreText.text = intScore.ToString();
    }
}
