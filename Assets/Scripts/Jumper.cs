using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public float force;
    public new Rigidbody2D rigidbody2D;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rigidbody2D.AddForce(Vector2.up * force);
        }

    }
}
