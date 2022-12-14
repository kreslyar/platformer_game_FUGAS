using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Potion : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textPotion;
    
    private int potionCount = 0;

    public int PotionCount
    {
        get => potionCount;
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Spike")
        {
            //lives += 100;
            lives -= 1;
            print("collision");

            if (lives == 0)
            {
                //var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                //SceneManager.LoadScene(currentSceneIndex);
                SceneManager.LoadScene("LikeMario");
            }
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Potion")
        {
            DecreaseHP();
            //print("Potion: " + potionCount);

            GameObject potionObject = collision.gameObject;
            Destroy(potionObject);
        }
    }

    private void DecreaseHP()
    {
        potionCount += 1;
        textPotion.text = potionCount.ToString();
        //lives -= 1;
        //print("trigger enter");

        /*if (potion == 0)
        {
            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
            //SceneManager.LoadScene("LikeMario");
        }*/
    }



}