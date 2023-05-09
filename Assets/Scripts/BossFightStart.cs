using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightStart : MonoBehaviour
{
    [SerializeField] GameObject bossObject;
    [SerializeField] GameObject ed1;

    private Doors doors;
    private BossFight boss;
    // Start is called before the first frame update
    void Start()
    {
        boss = bossObject.GetComponent<BossFight>();
        doors = ed1.GetComponent<Doors>();
    }

    void OnTriggerEnter2D(Collider2D playerCol)
    {
        if(playerCol.tag == "Player")
        {
            boss.Activate(); //CAUSES CRASH
            doors.Close();
            Destroy(gameObject);
        }
    }
}
