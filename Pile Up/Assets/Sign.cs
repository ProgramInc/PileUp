using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    bool isCurrentlyMoving;
    bool isShowing;
/*
    private void OnEnable()
    {
        LevelManager.OnlevelFailed += ShowUnShowCredits;
    }

    private void OnDisable()
    {
        LevelManager.OnlevelFailed -= ShowUnShowCredits;
    }
*/
    public void ShowUnShowCredits()
    {
        if (!isShowing && !isCurrentlyMoving)
        {
            ShowCredits();
            isCurrentlyMoving = true;
            isShowing = true;
        }
        else if (isShowing && !isCurrentlyMoving)
        {
            UnshowCreditsAndRestart();
            isCurrentlyMoving = true;
            isShowing = false;
        }
    }

    private void Start()
    {
        ShowCredits();
    }

    public void UnshowCreditsAndRestart()
    {
        LeanTween.rotateLocal(gameObject, new Vector3(90, 0, 0), 0.8f).setEaseInCubic().setOnComplete(RestartGame);
        /*AudioSFXManager.Instance.PlaySFX(1, SFXType.UI);*/
    }
    public void UnshowCredits()
    {
        LeanTween.rotateLocal(gameObject, new Vector3(90, 0, 0), 0.8f).setEaseInCubic();
        /*AudioSFXManager.Instance.PlaySFX(1, SFXType.UI);*/
    }

    private void ShowCredits()
    {
        LeanTween.rotateLocal(gameObject, Vector3.zero, 1.5f).setEaseOutElastic();
        /*AudioSFXManager.Instance.PlaySFX(0, SFXType.UI);
        AudioSFXManager.Instance.PlaySFX(2, SFXType.UI);*/
    }

    void RestartGame()
    {
        GameManager.Instance.RestartGame();
    }
}