using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           // PlayerMovement2D playerMovement = collision.GetComponent<PlayerMovement2D>();
            SceneManager.LoadScene("Level_2");
        }
    }
}
