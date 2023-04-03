using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScorer : MonoBehaviour
{
    bool hasScored;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Block"))
        {
            print("score");
            if (!hasScored)
            {
                hasScored = true;
                ScoreCounter.Instance.AddToScore();
            }
        }
    }

    public void SetHasScoredToTrue()
    {
        hasScored = true;
    }
}
