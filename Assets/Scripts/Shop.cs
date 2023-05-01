using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Shop : MonoBehaviour
{
    public static Dictionary<string, int> map = new Dictionary<string, int>
    {{"health",0},
        {"armor",0 },
        {"speed",0 },
        {"damage",0 }

    };

    public void addhealth()
    {
        if (CoinCollector.coins > 0)
        {
            map["health"]++;
            CoinCollector.coins = CoinCollector.coins - 1;
        }
    }
    public void adddamage()
    {
        if (CoinCollector.coins > 0)
        {
            map["damage"]++;
            CoinCollector.coins = CoinCollector.coins - 1;
        }
    }
    public void addarmor()
    {
        if (CoinCollector.coins > 0)
        {
            map["armor"]++;
            CoinCollector.coins = CoinCollector.coins - 1;
        }
    }
    public void addspeed()
    {
        if (CoinCollector.coins > 0)
        {
            map["speed"]++;
            CoinCollector.coins = CoinCollector.coins - 1;
        }
    }
    // Start is called before the first frame update
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }
}
