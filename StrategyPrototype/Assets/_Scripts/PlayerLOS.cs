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
    public TurretControl myTurret;

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
          //  Debug.Log(distanceToEnemy);
            if (Physics.Raycast(transform.position, direction,out hit, Mathf.Infinity) && distanceToEnemy < range && enemy != null)
            {
                Debug.DrawRay(transform.position, direction);
                enemy.GetComponent<EnemyControl>().isVisible = true;
            }

            //else { enemyVis = false; }

            if (Physics.Raycast(transform.position,direction,out hit, range) && hit.collider.tag == "UnitEnemy" )
            {
                
            }

            if (distanceToEnemy < shortestDistance)    // checks for closest
            {


                // -------------------- checks for closest in range AND within gun angle -------------------------- 
                if (myTurret.upPlaneOn == true && myTurret.downPlaneOn == false && myTurret.upperPlane.transform.position.y >= enemy.transform.position.y) // upper plane // downwards shooting
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
                

                if (myTurret.upPlaneOn == false && myTurret.downPlaneOn == true && myTurret.lowerPlane.position.y <= enemy.transform.position.y) // lower plane // upwards shooting
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
                

                if (myTurret.upPlaneOn == true && myTurret.downPlaneOn == true && myTurret.upperPlane.position.y >= enemy.transform.position.y && myTurret.lowerPlane.position.y <= enemy.transform.position.y) // within two planes
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
                

            }

            if (nearestEnemy != null && shortestDistance < range)   // >>>>>>> finalizes the target <<<<<<<
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
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,range);
      //  Gizmos.color = Color.yellow;
        
    }
}
