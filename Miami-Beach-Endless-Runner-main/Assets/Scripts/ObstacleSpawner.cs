using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Train Prefab")]
    public GameObject trainPrefab;

    [Header("Three Lane Positions")]
    public float leftLaneX = -5f;
    public float middleLaneX = 0f;
    public float rightLaneX = 5f;

    [Header("Spawn Settings")]
    public float spawnStartZ = 100f;
    public float spawnInterval = 60f;

    private Transform player;
    private float nextSpawnZ;

    private readonly float[] lanePositions = { -5f, 0f, 5f };

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject == null || trainPrefab == null)
        {
            Debug.LogError("ObstacleSpawner: Assign the Player tag and Train Prefab!");
            enabled = false;
            return;
        }

        player = playerObject.transform;
        nextSpawnZ = spawnStartZ;
    }

    void Update()
    {
        while (player.position.z + 100f >= nextSpawnZ)
        {
            SpawnTrain();
            nextSpawnZ += spawnInterval;
        }
    }

    void SpawnTrain()
    {
        int lane = Random.Range(0, lanePositions.Length);

        Vector3 spawnPosition = new Vector3(
            lanePositions[lane],
            0f,
            nextSpawnZ
        );

        Instantiate(trainPrefab, spawnPosition, Quaternion.identity);
    }
}