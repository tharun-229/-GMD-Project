using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Coin Prefab")]
    public GameObject coinPrefab;

    [Header("Lane Positions")]
    public float leftLaneX = -5f;
    public float middleLaneX = 0f;
    public float rightLaneX = 5f;

    [Header("Spawn Settings")]
    public float firstSpawnZ = 40f;
    public float spawnInterval = 25f;
    public float coinSpacing = 2f;
    public int coinsPerRow = 8;
    public float coinHeight = 1.2f;

    private Transform player;
    private float nextSpawnZ;

    private readonly float[] lanePositions = { -5f, 0f, 5f };

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject == null || coinPrefab == null)
        {
            Debug.LogError("CoinSpawner: Assign the Player tag and Coin Prefab!");
            enabled = false;
            return;
        }

        player = playerObject.transform;
        nextSpawnZ = firstSpawnZ;
    }

    void Update()
    {
        while (player.position.z + 60f >= nextSpawnZ)
        {
            SpawnCoins();
            nextSpawnZ += spawnInterval;
        }
    }

    void SpawnCoins()
    {
        int lane = Random.Range(0, lanePositions.Length);
        float x = lanePositions[lane];

        for (int i = 0; i < coinsPerRow; i++)
        {
            Vector3 position = new Vector3(
                x,
                coinHeight,
                nextSpawnZ + i * coinSpacing
            );

            Instantiate(coinPrefab, position, Quaternion.identity);
        }
    }
}