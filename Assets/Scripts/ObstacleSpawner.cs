using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject obstaclePrefab;
    private Dictionary<int, Vector3> spawnLocations = new Dictionary<int, Vector3>();
    public float respawnTime; //create setter for respawntime so that gameManager can set the respanwtime
    private float lastSpawnTime;

    void Start()
    {
        //gameManagerScript = FindObjectOfType<GameManagerScript>();

        spawnLocations.Add(0, new Vector3(17.0f, 4.0f, 0f));
        spawnLocations.Add(1, new Vector3(17.0f, 1.8f, 0f));
        spawnLocations.Add(2, new Vector3(17.0f, -0.3f, 0f));
        spawnLocations.Add(3, new Vector3(17.0f, -2.5f, 0f));

        //for spawning in the first frame
        lastSpawnTime = -respawnTime;
    }

    void Update()
    {
        SpawnObstacles();
    }

    private void SpawnObstacles()
    {
        //improved spawning
        if (Time.timeSinceLevelLoad >= lastSpawnTime + respawnTime)
        {
            List<int> dontSpawnLocs = new List<int>();
            for (int i = 0; i < Random.Range(1, 3); i++)
            {
                int index = Random.Range(0, spawnLocations.Count);
                while (dontSpawnLocs.Contains(index))
                {
                    index = Random.Range(0, spawnLocations.Count);
                }
                dontSpawnLocs.Add(index);
            }

            for (int i = 0; i < spawnLocations.Count; i++)
            {
                if (!dontSpawnLocs.Contains(i))
                {
                    Instantiate(obstaclePrefab, spawnLocations[i], Quaternion.identity);
                }
            }
            lastSpawnTime = Time.timeSinceLevelLoad;
        }

        // if (Time.timeSinceLevelLoad >= lastSpawnTime + respawnTime)
        // {
        //     List<int> alreadySpawned = new List<int>();
        //     for (int i = 0; i < Random.Range(2, spawnLocations.Count); i++)
        //     {
        //         int index = Random.Range(0, spawnLocations.Count);
        //         while (alreadySpawned.Contains(index))
        //         {
        //             index = Random.Range(0, spawnLocations.Count);
        //         }
        //         alreadySpawned.Add(index);
        //         Instantiate(obstaclePrefab, spawnLocations[index], Quaternion.identity);
        //     }
        //     lastSpawnTime = Time.timeSinceLevelLoad;
        // }
    }
}
