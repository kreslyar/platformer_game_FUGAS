
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{

    [SerializeField] private GameObject [] objLives;
    [SerializeField] private GameObject panelGameOver;
    public GameObject canvasMenu;
    //private int lives = 3;
    public void Update()
    {
        UpdateLives(UserDataController.Instance.Lives);
    }
    public void GameOver()
    {
        panelGameOver.SetActive(true);
    }

    public void LoadMenuPanel()
    {
        canvasMenu.SetActive(true);
    }

    public void UpdateLives(int lives)
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
