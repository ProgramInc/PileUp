using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public static Platform Instance;

    public List<GameObject> BlocksOnPlatform { get; private set; } = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (BlocksOnPlatform.Contains(collision.gameObject))
        {
            return;
        }
        else
        {
            BlocksOnPlatform.Add(collision.gameObject);

            if (BlocksOnPlatform.Count < 2)
            {
                ScoreCounter.Instance.AddToScore();
                collision.gameObject.GetComponent<BlockScorer>().SetHasScoredToTrue();
            }
        }
        
    }
}
