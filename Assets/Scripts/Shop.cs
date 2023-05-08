using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Shop : MonoBehaviour
{
    //initial shop values
    public static Dictionary<string, int> map = new Dictionary<string, int>
    {{"health",0},
        {"armor",0 },
        {"speed",0 },
        {"damage",0 }

    };
    //adds health when bought
    public void addhealth()
    {
        if (CoinCollector.coins > 0)
        {
            map["health"]++;
            CoinCollector.coins = CoinCollector.coins - 1;
        }
    }
    //add damge when bought
    public void adddamage()
    {
        if (CoinCollector.coins > 0)
        {
            map["damage"]++;
            CoinCollector.coins = CoinCollector.coins - 1;
        }
    }
    //add armor when bought
    public void addarmor()
    {
        if (CoinCollector.coins > 0)
        {
            map["armor"]++;
            CoinCollector.coins = CoinCollector.coins - 1;
        }
    }
    //add speed when bought
    public void addspeed()
    {
        if (CoinCollector.coins > 0)
        {
            map["speed"]++;
            CoinCollector.coins = CoinCollector.coins - 1;
        }
    }
    // Start is called before the first frame update
    //exits shop buttn go to next scene
    public void NextLevel()
    {
        if(ShopLoader.currentLevelIndex == 1)
            SceneManager.LoadScene(ShopLoader.currentLevelIndex + 2);
        else
            SceneManager.LoadScene(ShopLoader.currentLevelIndex + 1);
    }
}
