using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public bool playerISInLOS = false;
    public float fieldOfViewAngle=160f;
    public float losRadius = 45f;

   

    public GameObject playerPos; 



    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

     





        float distance = Vector3.Distance(transform.position,playerPos.transform.position);
        if (distance <= losRadius)
        {

            CheckLOS();
        }
    }

    void CheckLOS()
    {
       
        Vector3 direction = playerPos.transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);
        Debug.Log(direction);
        if (angle < fieldOfViewAngle * 0.5f)
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position,direction.normalized,out hit,losRadius))
            {
                if(hit.collider.tag== "UnitPlayer")
                {
                    playerISInLOS = true;
                    
                    
                }
            }
        }

    }
    


}
