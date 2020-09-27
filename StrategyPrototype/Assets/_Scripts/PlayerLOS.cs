using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLOS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float range = 15f;
    public float sightDist;

    public Transform target;
    public LayerMask mask;
  //  public Transform targetVisible;



    
    void Update()
    {
        UnitDetection();
    


    }

    public void UnitDetection()
    {
        //Ray ray;

        //RaycastHit hit;

     /*   
        var enemyVis = enemy.GetComponent<EnemyControl>().isVisible;  
        if (Physics.Raycast(transform.position, direction, out hits, range))
        {
            enemyVis = true;
        }
        */

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("UnitEnemy");

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
           
            var direction = enemy.transform.position - transform.position;
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            RaycastHit hit;
            Debug.Log(distanceToEnemy);
            if (Physics.Raycast(transform.position, direction,out hit, Mathf.Infinity) && distanceToEnemy < range)
            {
                Debug.DrawRay(transform.position, direction);
                enemy.GetComponent<EnemyControl>().isVisible = true;
            }

            //else { enemyVis = false; }

            Debug.Log("test");
            if (Physics.Raycast(transform.position,direction,out hit, range) && hit.collider.tag == "UnitEnemy" )
            {
                
            }

            if (distanceToEnemy < shortestDistance)    // checks for closest AND visible
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;   // this enemy is the closest
                                        //  enemyVis = true;
                
            }

            if (nearestEnemy != null && shortestDistance < range)
            {
                target = nearestEnemy.transform;
                
            }
            else
            {
                target = null;
            }

            //   Debug.DrawRay(transform.position)
        }

    }






    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
      //  Gizmos.color = Color.yellow;
        
    }
}
