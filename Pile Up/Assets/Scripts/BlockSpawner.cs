using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public static BlockSpawner Instance;
    [SerializeField] GameObject blockPrefab;
    [SerializeField] float xOffsetInstantiantion = -2.3f;
    [SerializeField] float spawnDelay;
    [SerializeField] Sprite[] blockSprites;
    GameObject currentBlock;
    public List<GameObject> ActiveBlocks { get; private set; } = new List<GameObject>();
    public delegate void BlockReleasedAction();
    public static BlockReleasedAction OnBlockReleased;

    private void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        OnBlockReleased += SpawnNewBlockWrapper;
        LevelManager.OnlevelFailed += DestroyCurrentBlock;
    }
    private void OnDisable()
    {
        OnBlockReleased -= SpawnNewBlockWrapper;
        LevelManager.OnlevelFailed -= DestroyCurrentBlock;
    }

    void Start()
    {
        SpawnNewBlockWrapper();
    }

    void SpawnNewBlockWrapper()
    {
        if (!LevelManager.Instance.isLevelFailed)
        {
            StartCoroutine(nameof(SpawnNewBlock)); 
        }
    }

    private IEnumerator SpawnNewBlock()
    {
        float spawnTimer = spawnDelay;
        while (spawnTimer > 0)
        {
            if (LevelManager.Instance.isLevelFailed)
            {
                yield break;
            }
            else
            {
                spawnTimer -= Time.deltaTime;
                yield return null; 
            }
        }
        currentBlock = Instantiate(blockPrefab, new Vector3(xOffsetInstantiantion, gameObject.transform.position.y, 0), Quaternion.identity);
        currentBlock.GetComponent<SpriteRenderer>().sprite = blockSprites[Random.Range(0, blockSprites.Length)];
        ActiveBlocks.Add(currentBlock);
    }

    void DestroyCurrentBlock()
    {
        Destroy(currentBlock);
    }
}
