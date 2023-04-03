using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI scoreNumberText;
    public int CurrentScore { get; private set; }
    public int HighScore { get; private set; }

    private void OnEnable()
    {
        LevelManager.OnlevelFailed += UnshowScore;
    }
    private void OnDisable()
    {
        LevelManager.OnlevelFailed -= UnshowScore;
    }

    void ResetCurrentScore()
    {
        CurrentScore = 0;
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
        CurrentScore = 0;
        scoreNumberText.text = "00";
    }

    public void AddToScore()
    {
        CurrentScore += 10;
        scoreNumberText.text = CurrentScore.ToString();
    }

    void UnshowScore()
    {
        scoreText.gameObject.SetActive(false);  
        scoreNumberText.gameObject.SetActive(false);
    }
}
