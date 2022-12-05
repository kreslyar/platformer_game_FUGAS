
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int lives;

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
        if (collision.tag == "Spike")
        {
            DecreaseHP();

            GameObject spikeObject = collision.gameObject;
            Destroy(spikeObject);
        }
    }

    private void DecreaseHP()
    {
        //lives += 100;
        lives -= 1;
        print("trigger enter");

        if (lives == 0)
        {
            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
            //SceneManager.LoadScene("LikeMario");
        }
    }



}
