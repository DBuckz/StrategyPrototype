using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWanderAI : MonoBehaviour
{

    public bool playerIsInLOS = false;
    public bool playerIsInLOS1 = false;
    public bool playerIsInLOS2 = false;
    public float fieldOfViewAngle = 160f;
    public float losRadius = 45f;
//vision 
    //currently cant get enemy to stop close to player 
    public float viewDis = 5;



    public float moveSpeed = 3f;
    public float rotSpeed = 100f;

    private bool isWandering = false;

    private bool isRotLeft = false;
    private bool isRotRight = false;
    private bool isWalking = false;
    private bool isMovingUp = false;
    private bool isMovingDown = false;
    public Action type;
    
    public GameObject[] playerPos;
   
    void Update()
    {

        playerIsInLOS = false;
        playerIsInLOS1 = false;
        playerIsInLOS2 = false;
        float distance = Vector3.Distance(transform.position, playerPos[0].transform.position);
        if (distance <= losRadius)
        {

            CheckLOS();
        }


        float distance1 = Vector3.Distance(transform.position, playerPos[1].transform.position);
        if (distance1 <= losRadius)
        {

            CheckLOS1();
        }

        float distance2 = Vector3.Distance(transform.position, playerPos[2].transform.position);
        if (distance2<= losRadius)
        {

            CheckLOS2();
        }




        if (playerIsInLOS == true || playerIsInLOS1 == true || playerIsInLOS2 == true)
        {
            type = Action.Attack;
        }
        else
       {
           type = Action.Wander;
        }

        if (type == Action.Wander)
        {
            if (isWandering == false)
            {
                StartCoroutine(Wander());
            }
            if (isRotRight == true)
            {
                transform.Rotate(transform.up * Time.deltaTime * rotSpeed);

            }

            if (isRotLeft == true)
            {
                transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);

            }
            if (isWalking == true)
            {
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
            if (isMovingUp == true)
            {
                transform.position += transform.up * moveSpeed * Time.deltaTime;
            }
            if (isMovingDown == true)
            {
                transform.position -= transform.up * moveSpeed * Time.deltaTime;
            }
        }else if (type == Action.Attack)
        {
            float distanceP1 = Vector3.Distance(transform.position, playerPos[0].transform.position);
           float distanceP2 = Vector3.Distance(transform.position,playerPos[1].transform.position);
            float distanceP3 = Vector3.Distance(transform.position, playerPos[2].transform.position);
         
           if(distanceP1<=distanceP2 && distanceP1 <= distanceP3 && playerIsInLOS == true)
            {
                 transform.LookAt(playerPos[0].transform);
                transform.position = Vector3.MoveTowards(transform.position, playerPos[0].transform.position, .03f) ;
            }
            if (distanceP2 < distanceP1 && distanceP2 < distanceP3 && playerIsInLOS1 == true)
            {
                transform.LookAt(playerPos[1].transform);
                transform.position = Vector3.MoveTowards(transform.position, playerPos[1].transform.position, .03f);
            }
            if (distanceP3 < distanceP2 && distanceP3 < distanceP1 && playerIsInLOS2==true)
            {
                transform.LookAt(playerPos[2].transform);
                transform.position = Vector3.MoveTowards(transform.position, playerPos[2].transform.position, .03f);
            }
           /*   Vector3 newplayerPos = playerPos.transform.position;
             newplayerPos.y = transform.position.y;
             newplayerPos.z = transform.position.z;

             float distance = Vector3.Distance(transform.position, newplayerPos);
             if (distance<5)
             {
                 newplayerPos.x = transform.position.x ;
             }

             Debug.Log(distance);
             */

            // here is how it targets the player
        }
       



    }



    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotWait = Random.Range(1, 4);

        int rotLorR = Random.Range(1, 2);
        int moveUporDown = Random.Range(0, 10);
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 5);

        isWandering = true;
        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        if (moveUporDown <= 0)
        {
            isMovingUp = false;
            isMovingDown = false;
        }
        if (moveUporDown == 1)
        {
            isMovingUp = true;
            isMovingDown = false;
        }

        if (moveUporDown == 2)
        {
            isMovingDown = true;
            isMovingUp = false;
        }
        yield return new WaitForSeconds(walkTime);
        isMovingDown = false;
        isMovingUp = false;
        isWalking = false;
        yield return new WaitForSeconds(rotWait);
        if (rotLorR == 1)
        {

            isRotRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotRight = false;

        }
        if (rotLorR == 2)
        {
            isRotLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotLeft = false;


        }


        isWandering = false;
    }







    void CheckLOS()
    {

        Vector3 direction = playerPos[0].transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);
        
        if (angle < fieldOfViewAngle * 0.5f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction.normalized, out hit, losRadius))
            {
                if (hit.collider.tag == "UnitPlayer")
                {
                    playerIsInLOS = true;


                }
                else playerIsInLOS = false;

            }
        }
        

    }
    void CheckLOS1()
    {
        Vector3 direction = playerPos[1].transform.position - transform.position;
    float angle = Vector3.Angle(direction, transform.forward);
        
        if (angle < fieldOfViewAngle * 0.5f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction.normalized, out hit, losRadius))
            {
                if (hit.collider.tag == "UnitPlayer")
                {
                    playerIsInLOS1 = true;


                }
                else playerIsInLOS1 = false;

            }
        }
     }


    void CheckLOS2()
    {
        Vector3 direction = playerPos[2].transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);
    
        if (angle < fieldOfViewAngle * 0.5f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction.normalized, out hit, losRadius))
            {
                if (hit.collider.tag == "UnitPlayer")
                {
                    playerIsInLOS2 = true;


                }
                else playerIsInLOS2 = false;

            }
        }
    }

    public enum     Action
        {
        Wander,
        Attack,
        Chase,
        }

    
}
