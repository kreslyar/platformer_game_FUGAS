using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAndPause : MonoBehaviour
{
    private bool paused;

    public GameObject canvasMenu;

    void Start()
    {
        paused = false;
    }

    public void Pause()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0.000001f;
            canvasMenu.SetActive(true);
        }

        if (!paused)
        {
            Time.timeScale = 1f;
            canvasMenu.SetActive(false);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level_1");
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
