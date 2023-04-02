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
    }
    private void OnDisable()
    {
        OnBlockReleased -= SpawnNewBlockWrapper;
    }

    void Start()
    {
        SpawnNewBlockWrapper();
    }

    void Update()
    {
        if (!LevelManager.Instance.isLevelFailed)
        {
            foreach (GameObject block in ActiveBlocks)
            {
                if (block.transform.position.y < -5)
                {
                    LevelManager.OnlevelFailed?.Invoke();
                    DestroyCurrentBlock();
                    break;
                }
            }
        }
    }

    void SpawnNewBlockWrapper()
    {
        StartCoroutine(nameof(SpawnNewBlock));
    }

    private IEnumerator SpawnNewBlock()
    {
        float spawnTimer = spawnDelay;
        while (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
            yield return null;
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
