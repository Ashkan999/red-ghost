using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    //private GameManagerScript gameManagerScript;
    public static float speed;
    public Rigidbody2D rb2D;

    void Start()
    {
        //gameManagerScript = FindObjectOfType<GameManagerScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position += Vector3.left * gameManagerScript.currentSpeed * Time.deltaTime;

        rb2D.MovePosition(rb2D.position + Vector2.left * speed * Time.fixedDeltaTime);

        //transform.position += Vector3.left * FindObjectOfType<GameManagerScript>().startSpeed * Time.deltaTime;
    }
}
