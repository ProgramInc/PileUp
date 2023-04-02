using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public delegate void LevelFailedAction();
    public static LevelFailedAction OnlevelFailed;
    public bool isLevelFailed { get; private set; }

    public static LevelManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        OnlevelFailed += LevelFailed;
    }

    private void OnDisable()
    {
        OnlevelFailed -= LevelFailed;
    }

    private void LevelFailed()
    {
        isLevelFailed = true;
        print("LevelFailed");
    }
}
