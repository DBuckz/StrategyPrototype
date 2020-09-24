using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationDestroy : MonoBehaviour
{

    private void Start()
    {
        playerCont = GameObject.Find("CursorPosCheck");
        


    }

    public GameObject playerCont;
   // public GameObject targetCol;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "UnitPlayer")
        {
            Destroy(gameObject);
        }
        
    }
}
