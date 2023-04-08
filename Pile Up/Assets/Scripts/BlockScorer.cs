using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScorer : MonoBehaviour
{
    bool hasScored;
    ParticleSystem particle;
    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.position.y < transform.position.y)
        {
            AudioSFXManager.Instance.PlaySFX(Random.Range(6, 8));
            particle.Emit(Random.Range(15, 31));
        }
        
        
        if (collision.gameObject.CompareTag("Block"))
        {
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
