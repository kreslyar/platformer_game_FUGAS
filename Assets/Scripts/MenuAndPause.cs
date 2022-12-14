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
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        UserDataController.Instance.ResetData();
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        canvasMenu.SetActive(false);
    }
    public void StartLevel()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1f;
        UserDataController.Instance.ResetData();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
