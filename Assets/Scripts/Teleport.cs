using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    [SerializeField] private GameObject panelWork;
    public GameObject canvasMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Work();
            // PlayerMovement2D playerMovement = collision.GetComponent<PlayerMovement2D>();
            //SceneManager.LoadScene("Level_2");

        }

        
    }

    public void Work()
    {
        panelWork.SetActive(true);
    }

    public void LoadMenuPanel()
    {
        canvasMenu.SetActive(true);
    }
}
