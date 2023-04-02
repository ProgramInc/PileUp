using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    List<GameObject> blocksOnPlatform = new List<GameObject>();
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (blocksOnPlatform.Contains(collision.gameObject))
        {
            return;
        }
        else
        {
            blocksOnPlatform.Add(collision.gameObject);
            if (blocksOnPlatform.Count>1)
            {
                LevelManager.OnlevelFailed?.Invoke();
            }
        }
    }
}
