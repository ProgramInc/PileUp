using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance;
    /*[SerializeField] Image scoreImage;*/
    [SerializeField] TextMeshProUGUI scoreNumberText;
    public int CurrentScore { get; private set; }
    public int HighScore { get; private set; }
    [SerializeField]RectTransform topPanel;

    public bool newHighScore;


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
        /*scoreImage = GameObject.FindGameObjectWithTag("ScoreImage").GetComponent<Image>();*/
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
        if (CurrentScore%100==0)
        {
            AudioSFXManager.Instance.PlaySFX(5);
        }
        else if (CurrentScore%50 == 0 && CurrentScore % 100 !=0)
        {
            AudioSFXManager.Instance.PlaySFX(4);
        }

        if (CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
            if (!newHighScore)
            {
                newHighScore = true;
            }
        }
        AudioSFXManager.Instance.PlaySFX(Random.Range(0, 2));
    }

    void UnshowScore()
    {
        topPanel.gameObject.SetActive(false);
       /* scoreImage.gameObject.SetActive(false);
        scoreNumberText.gameObject.SetActive(false);*/
    }

    void SaveScore()
    {
        if (CurrentScore <= 30)
        {
            AudioSFXManager.Instance.PlaySFX(9);
        }
        int _highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (HighScore > _highScore)
        {
            PlayerPrefs.SetInt("HighScore", HighScore);
            
            if (HighScore > 30)
            {
                AudioSFXManager.Instance.PlaySFX(8);
            }
        }
    }

    void LoadHighScore()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
