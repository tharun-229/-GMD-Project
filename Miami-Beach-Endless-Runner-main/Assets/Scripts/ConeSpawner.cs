using UnityEngine;

public class ConeSpawner : MonoBehaviour
{
    public GameObject conePrefab;

    public float leftLaneX = -2.27245f;
    public float middleLaneX = 2.72755f;
    public float rightLaneX = 7.72755f;

    public float spawnAheadDistance = 100f;
    public float spawnInterval = 25f;

    private Transform player;
    private float nextSpawnZ;

    void Start()
    {
        GameObject playerObject =
            GameObject.FindGameObjectWithTag("Player");

        if (playerObject == null || conePrefab == null)
        {
            Debug.LogError("Assign Player and Cone Prefab!");
            enabled = false;
            return;
        }

        player = playerObject.transform;
        nextSpawnZ = player.position.z + spawnAheadDistance;
    }

    void Update()
    {
        while (player.position.z + spawnAheadDistance >= nextSpawnZ)
        {
            SpawnCone();
            nextSpawnZ += spawnInterval;
        }
    }

    void SpawnCone()
    {
        float[] lanes = {
            leftLaneX,
            middleLaneX,
            rightLaneX
        };

        int lane = Random.Range(0, 3);

        Vector3 position = new Vector3(
            lanes[lane], 0f, nextSpawnZ
        );

        Instantiate(conePrefab, position, Quaternion.identity);
    }
}