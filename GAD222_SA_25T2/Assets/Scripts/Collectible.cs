using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    public static int totalCollectibles = 0;
    public static int collectedCount = 0;

    void Start()
    {
                totalCollectibles++;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
    
            collectedCount++;

            // Destroy this collectible
            Destroy(gameObject);

            // Check if all collectibles are collected
            if (collectedCount >= totalCollectibles)
            {
                // Load next scene (make sure to add it in Build Settings)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
