using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTweener : MonoBehaviour
{
    void Start()
    {
        LeanTween.moveLocalY(gameObject, 775f, 1f).setEaseOutBounce();
    }
}
