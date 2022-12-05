using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float movingY;
    float speed = 4f;

    bool movingUp = true;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 7f)
        {
            movingUp = false;
        }
        else if (transform.position.y < -2f)
        {
            movingUp = true;
        }
        if (movingUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
    }
}
