using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWanderAI : MonoBehaviour
{
    public float viewDis=5;



    public float moveSpeed = 3f;
    public float rotSpeed = 100f;
    
    private bool isWandering = false;

    private bool isRotLeft = false;
    private bool isRotRight = false;
    private bool isWalking = false;
    private bool isMovingUp=false;
    private bool isMovingDown=false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
        if(isMovingUp==true)
        {
            transform.position += transform.up * moveSpeed * Time.deltaTime;
        }
        if (isMovingDown == true)
        {
            transform.position -= transform.up * moveSpeed * Time.deltaTime;
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
        if (moveUporDown <=0)
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


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * viewDis);
    }
}
