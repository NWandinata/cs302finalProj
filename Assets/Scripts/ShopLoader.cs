using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopLoader : MonoBehaviour
{
    public string levelToLoad;
    public static int currentLevelIndex;

    // Loads shop upon player entering goal and helps shop track the next level to load
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
            currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        }
    }
}

