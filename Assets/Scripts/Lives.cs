
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{

    [SerializeField] private GameObject [] objLives;
    [SerializeField] private GameObject panelGameOver;
    public GameObject canvasMenu;
    private int lives = 3;

    public void AddLives()
    {
        lives++;
        UpdateLives();
    }

    public void RemoveLives()
    {
        lives--;
        UpdateLives();
    }

    public void GameOver()
    {
        panelGameOver.SetActive(true);
    }

    public void LoadMenuPanel()
    {
        canvasMenu.SetActive(true);
    }

    void UpdateLives()
    {
        for (int i = 0; i < 3; i++)
        {
            if (lives > i)
            {
                objLives[i].SetActive(true);
            }
            else
            {
                objLives[i].SetActive(false);
            }
        }
    }

}
