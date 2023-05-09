using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject boss;


    // Update is called once per frame
    void Update()
    {
       if(boss == null)
        {
            Destroy(gameObject); //deletes doors after boss is defeated
        } 
    }
    public void Close()
    {
        transform.Translate(0, -5, 0);
    }

    /*public void Open()
    {
        transform.Translate(0, 5, 0);
    }*/
}
