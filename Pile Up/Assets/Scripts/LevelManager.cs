using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public delegate void LevelFailedAction();
    public static event LevelFailedAction OnlevelFailed;
    public bool isLevelFailed { get; private set; }
    [SerializeField] GameObject pauseButton;
    public static LevelManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        OnlevelFailed += LevelFailed;
        OnlevelFailed += HidePauseButton;
    }

    private void OnDisable()
    {
        OnlevelFailed -= LevelFailed;
        OnlevelFailed -= HidePauseButton;
    }

    private void LevelFailed()
    {
        isLevelFailed = true;
        print("LevelFailed");
    }

    private void Update()
    {
        if (!isLevelFailed)
        {
            foreach (GameObject block in BlockSpawner.Instance.ActiveBlocks)
            {
                if (block.transform.position.y < -5)
                {
                    /*isLevelFailed = true;*/
                    OnlevelFailed?.Invoke();
                    break;
                }
            }
        }
        if (Platform.Instance.BlocksOnPlatform.Count > 1)
        {
            if (!isLevelFailed)
            {
                OnlevelFailed?.Invoke();
            }
        }
    }

    void HidePauseButton()
    {
        pauseButton.SetActive(false);
    }
}
