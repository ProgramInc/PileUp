using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance;
    [SerializeField] TextMeshProUGUI scoreNumberText;
    int currentScore;
    int highScore;

    void ResetCurrentScore()
    {
        currentScore = 0;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        currentScore = 0;
        scoreNumberText.text = "00";
    }

    public void AddToScore()
    {
        currentScore += 10;
        scoreNumberText.text = currentScore.ToString();
    }
}
