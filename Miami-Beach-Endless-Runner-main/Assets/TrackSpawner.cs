using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    public GameObject trackPrefab;
    public float trackLength = 20f;
    public int tracksOnScreen = 6;
    public float laneDistance = 5f;

    private float nextSpawnZ = 0f;
    private Transform player;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject == null)
        {
            Debug.LogError("Player tag is missing!");
            enabled = false;
            return;
        }

        player = playerObject.transform;

        for (int i = 0; i < tracksOnScreen; i++)
        {
            SpawnTrack();
        }
    }

    void Update()
    {
        if (player.position.z + 100f > nextSpawnZ)
        {
            SpawnTrack();
        }
    }

    void SpawnTrack()
    {
        for (int lane = -1; lane <= 1; lane++)
        {
            Vector3 position = new Vector3(
                lane * laneDistance,
                0.2f,
                nextSpawnZ
            );

            Instantiate(trackPrefab, position, Quaternion.identity);
        }

        nextSpawnZ += trackLength;
    }
}