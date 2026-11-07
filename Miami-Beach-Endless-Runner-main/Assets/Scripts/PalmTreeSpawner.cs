using UnityEngine;

public class PalmTreeSpawner : MonoBehaviour
{
    [Header("Palm Tree Settings")]
    public GameObject palmTreePrefab;
    public float spawnDistance = 25f;
    public float treeSpacing = 15f;

    [Header("Side Positions")]
    public float leftSideX = -12f;
    public float rightSideX = 12f;

    private Transform player;
    private float nextSpawnZ = 150f;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject == null || palmTreePrefab == null)
        {
            Debug.LogError("PalmTreeSpawner: Assign the Player and Palm Tree prefab!");
            enabled = false;
            return;
        }

        player = playerObject.transform;

        // Create trees along the initial section.
        while (nextSpawnZ < player.position.z + spawnDistance)
        {
            SpawnTrees();
        }
    }

    void Update()
    {
        while (nextSpawnZ < player.position.z + spawnDistance)
        {
            SpawnTrees();
        }
    }

    void SpawnTrees()
    {
        Vector3 leftPosition = new Vector3(leftSideX, 0f, nextSpawnZ);
        Vector3 rightPosition = new Vector3(rightSideX, 0f, nextSpawnZ);

        Instantiate(palmTreePrefab, leftPosition, Quaternion.identity);
        Instantiate(palmTreePrefab, rightPosition, Quaternion.Euler(0f, 180f, 0f));

        nextSpawnZ += treeSpacing;
    }
}