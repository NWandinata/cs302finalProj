using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string levelToLoad;
    public static int currentLevelIndex;

    // Loads next level upon player entering goal (usually shop or end scene)
    // and helps shop track the next level to load
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
            currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        }
    }
}

