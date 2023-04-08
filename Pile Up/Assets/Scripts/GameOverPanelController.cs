using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameOverPanelController : MonoBehaviour
{
    [SerializeField] RectTransform gameOverPanel;
    [SerializeField] TextMeshProUGUI scoreNumberText;
    [SerializeField] TextMeshProUGUI highScoreNumberText;


    private void OnEnable()
    {
        LevelManager.OnlevelFailed += ShowScore;
    }

    private void OnDisable()
    {
        LevelManager.OnlevelFailed -= ShowScore;
    }
    void ShowScore()
    {
        scoreNumberText.text = ScoreCounter.Instance.CurrentScore.ToString();
        highScoreNumberText.text = ScoreCounter.Instance.HighScore.ToString();
        gameOverPanel.gameObject.SetActive(true);
    }

}
