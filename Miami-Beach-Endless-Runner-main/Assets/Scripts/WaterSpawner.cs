using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    [Header("Water Settings")]
    public GameObject waterPrefab;
    public float waterLength = 200f;
    public float waterX = -60f;

    private Transform player;
    private float nextSpawnZ = 250f;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject == null || waterPrefab == null)
        {
            Debug.LogError("WaterSpawner: Assign the Player tag and Water Prefab.");
            enabled = false;
            return;
        }

        player = playerObject.transform;
    }

    void Update()
    {
        while (player.position.z + 100f >= nextSpawnZ)
        {
            SpawnWater();
        }
    }

    void SpawnWater()
    {
        Vector3 spawnPosition = new Vector3(waterX, -0.1f, nextSpawnZ);

        Instantiate(waterPrefab, spawnPosition, Quaternion.identity);

        nextSpawnZ += waterLength;
    }
}