using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMover : MonoBehaviour
{
    float currentHeight;
    [SerializeField] float moveUpSpeed;
    [SerializeField] GameObject moveContainer;
    [SerializeField] float moveUpOffset;
    [SerializeField] int moveUpAfter;
    private void OnEnable()
    {
        BlockSpawner.OnBlockReleased += MoveUpWrapper;
    }

    private void OnDisable()
    {
        BlockSpawner.OnBlockReleased -= MoveUpWrapper;
    }

    void Start()
    {
        currentHeight = moveContainer.transform.position.y;
    }


    private void MoveUpWrapper()
    {
        if (BlockSpawner.Instance.ActiveBlocks.Count < moveUpAfter)
        {
            return;
        }
        else
        {
            StartCoroutine(nameof(MoveGameUp));
        }
    }

    private IEnumerator MoveGameUp()
    {
        float nextHeight = currentHeight + moveUpOffset;
        while (currentHeight < nextHeight)
        {
            currentHeight += Time.deltaTime * moveUpSpeed;
            moveContainer.transform.position = new Vector3(0, currentHeight, -10);
            yield return null;
        }
    }
}
