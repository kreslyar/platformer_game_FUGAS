using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UserDataController : MonoBehaviour
{
    public static UserDataController Instance { get; private set; }

    public int Potion { get; private set; }

    public int Lives { get; private set; }

private void Awake()
    {

        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            LoadAllData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadAllData()
    {
        Potion = PlayerPrefs.GetInt("potion", 0);
        Lives = PlayerPrefs.GetInt("lives", 3);
    }
    public void ResetData()
    {
        Potion = 0;
        Lives = 3;
        PlayerPrefs.SetInt("potion", Potion);
        PlayerPrefs.SetInt("lives", Lives);
    }

    public void AddPotion(int potion)
    {
        Potion += potion;
        PlayerPrefs.SetInt("potion", Potion);
    }

    public void AddLives(int lives)
    {
        Lives += lives;
        PlayerPrefs.SetInt("lives", Lives);
    }

    public void RemoveLives(int lives)
    {
        Lives -= lives;
        PlayerPrefs.SetInt("lives", Lives);
        if (lives == 0)
        {
            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
            //PlayerPrefs.SetInt("lives", Lives);
        }
    }

    /*public void UpdateLives(int lives)
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
    }*/
}
