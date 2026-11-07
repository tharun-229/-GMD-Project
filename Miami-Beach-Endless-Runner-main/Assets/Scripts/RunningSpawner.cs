using UnityEngine;

public class RunningSpawner : MonoBehaviour
{
    public GameObject runningTrackPrefab;
    public float trackLength = 200f;

    private float nextSpawnZ = 150f;
    private Transform player;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject == null || runningTrackPrefab == null)
        {
            Debug.LogError("Assign the Player and RunningTrack prefab!");
            enabled = false;
            return;
        }

        player = playerObject.transform;
    }

    void Update()
    {
        if (player.position.z + 100f >= nextSpawnZ)
        {
            SpawnTrack();
        }
    }

    void SpawnTrack()
    {
        Vector3 position = new Vector3(0f, 0.1f, nextSpawnZ + trackLength / 2f);

        Instantiate(runningTrackPrefab, position, Quaternion.identity);

        nextSpawnZ += trackLength;
    }
}