using UnityEngine.SceneManagement;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject[] objHearts;
    [SerializeField] private GameObject panelGameOver;
    private int heart = 3;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void AddHeart()
    {
        heart++;
        UpdateHeart();
    }
    public void RemoveHeart()
    {
        heart--;
        UpdateHeart();
    }

    public void GameOver()
    {
        panelGameOver.SetActive(true);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    void UpdateHeart()
    {
        for (int i = 0; i < 3; i++)
        {
            if (heart>i)
            {
                objHearts[i].SetActive(true);
            }
            else
            {
                objHearts[i].SetActive(false);
            }
        }
    }

}
