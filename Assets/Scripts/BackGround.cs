using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public static float speed;
    public float relativeSpeed;
    public float endPos;
    public float startPos;

    void FixedUpdate()
    {
        transform.position += Vector3.left * speed * relativeSpeed * Time.fixedDeltaTime;

        if (transform.position.x <= endPos)
        {
            transform.position = new Vector2(startPos, transform.position.y);
        }
    }
}
