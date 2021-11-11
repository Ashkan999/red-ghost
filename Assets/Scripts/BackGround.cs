using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed;

    public float endPos;
    public float startPos;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= endPos) {
            transform.position = new Vector2(startPos, transform.position.y);
        }
    }
}
