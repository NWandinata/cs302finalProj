using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Shop : MonoBehaviour
{
    public static int health=0;
    public static int armor = 0;
    public void addhealth()
    {
        health++;
    }
    public void addarmor()
    {
        armor++;

    }
    // Start is called before the first frame update
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }
}
