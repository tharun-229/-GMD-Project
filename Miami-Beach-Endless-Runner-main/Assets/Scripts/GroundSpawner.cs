using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [Header("Ground Settings")]
    public GameObject groundPrefab;
    public float groundLength = 200f;

    private float nextSpawnZ = 250f;
    private Transform player;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject == null)
        {
            Debug.LogError("GroundSpawner: Player not found! Check the Player tag.");
            enabled = false;
            return;
        }

        if (groundPrefab == null)
        {
            Debug.LogError("GroundSpawner: Assign the BeachGround prefab!");
            enabled = false;
            return;
        }

        player = playerObject.transform;
    }

    void Update()
    {
        if (player.position.z + 100f >= nextSpawnZ)
        {
            SpawnGround();
        }
    }

    void SpawnGround()
    {
        Vector3 spawnPosition = new Vector3(0f, 0.1f, nextSpawnZ);

        Instantiate(groundPrefab, spawnPosition, Quaternion.identity);

        nextSpawnZ += groundLength;
    }
}