using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance;
    [SerializeField] Image scoreImage;
    [SerializeField] TextMeshProUGUI scoreNumberText;
    public int CurrentScore { get; private set; }
    public int HighScore { get; private set; }


    private void OnEnable()
    {
        LevelManager.OnlevelFailed += UnshowScore;
        LevelManager.OnlevelFailed += SaveScore;
    }
    private void OnDisable()
    {
        LevelManager.OnlevelFailed -= UnshowScore;
        LevelManager.OnlevelFailed -= SaveScore;
    }

    void ResetCurrentScore()
    {
        CurrentScore = 0;
    }

    private void Awake()
    {
        Instance = this;
        scoreImage = GameObject.FindGameObjectWithTag("ScoreImage").GetComponent<Image>();
        scoreNumberText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        CurrentScore = 0;
        scoreNumberText.text = "00";
        LoadHighScore();
    }

    public void AddToScore()
    {

        CurrentScore += 10;
        scoreNumberText.text = CurrentScore.ToString();
        if (CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
        }
    }

    void UnshowScore()
    {
        scoreImage.gameObject.SetActive(false);
        scoreNumberText.gameObject.SetActive(false);
    }

    void SaveScore()
    {
        int _highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (HighScore > _highScore)
        {
            PlayerPrefs.SetInt("HighScore", HighScore);
        }
    }

    void LoadHighScore()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        print("highscore is " + HighScore);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
