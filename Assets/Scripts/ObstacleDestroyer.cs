using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    public GameObject obstacleEffect;

    public void DestroyObstacle(GameObject obstacle)
    {
        Destroy(Instantiate(obstacleEffect, obstacle.transform.position, Quaternion.identity), 2f);
        Destroy(obstacle);
    }
}
