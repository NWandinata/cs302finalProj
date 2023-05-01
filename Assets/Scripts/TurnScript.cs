using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D enemyCol)
    {
        if(enemyCol.tag == "Enemy")
        {
            enemyCol.transform.Rotate(0f, 180f, 0f);


        }
    }
}
