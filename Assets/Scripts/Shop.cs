using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Shop : MonoBehaviour
{
    public static int health=0;
    public static int armor = 0;
    public static int speed = 0;
    public static int damage = 0;
    public void addhealth()
    {
        if (CoinCollector.coins > 0)
        {
            health++;
            CoinCollector.coins = CoinCollector.coins - 1;
        }
    }
    public void adddamage()
    {
        if (CoinCollector.coins > 0)
        {
            damage++;
            CoinCollector.coins = CoinCollector.coins - 1;
        }
    }
    public void addarmor()
    {
        if (CoinCollector.coins > 0)
        {
            armor++;
            CoinCollector.coins = CoinCollector.coins - 1;
        }
    }
    public void addspeed()
    {
        if (CoinCollector.coins > 0)
        {
            speed++;
            CoinCollector.coins = CoinCollector.coins - 1;
        }
    }
    // Start is called before the first frame update
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }
}
