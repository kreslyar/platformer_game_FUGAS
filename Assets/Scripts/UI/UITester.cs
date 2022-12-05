
using UnityEngine;
using TMPro;

public class UITester : MonoBehaviour
{
    /*public TextMeshProUGUI someTextMeshPro;
    public void Play() 
    {
        print ("Play");

    }

    public void Exit()
    {
        gameObject.SetActive(false);
    }*/

    public void PauseOn()
    {
        Time.timeScale = 0.000001f;
    }

    public void PauseOff()
    {
        Time.timeScale = 1f;
    }
}
