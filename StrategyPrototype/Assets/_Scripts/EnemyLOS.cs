using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLOS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }



    public float range = 18f;
    public float sightDist;

    public Transform target;
    public TurretControl myTurret;

    // Update is called once per frame
    void Update()
    {
        PlayerUnitDetection();
        


    }

    
    public void PlayerUnitDetection()
    {

        GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("UnitPlayer");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestPlayerUnit = null;

        foreach (GameObject p_Unit in playerUnits)
        {

            var direction = p_Unit.transform.position - transform.position;
            float distanceToPlayer = Vector3.Distance(transform.position, p_Unit.transform.position);

            RaycastHit hit;
            
            if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity) && distanceToPlayer < range)
            {
                Debug.DrawRay(transform.position, direction, Color.red);
            //    p_Unit.GetComponent<EnemyControl>().isVisible = true;
            }

            if (Physics.Raycast(transform.position, direction, out hit, range) && hit.collider.tag == "UnitPlayer")
            {

            }

            if (distanceToPlayer < shortestDistance && myTurret != null)    // checks for closest AND within gun angle AND has turret
            {
                Debug.Log("Check Player Target");
                if (myTurret.upPlaneOn == true && myTurret.downPlaneOn == false && myTurret.upperPlane.transform.position.y >= p_Unit.transform.position.y) // upper plane // downwards shooting
                {
                    shortestDistance = distanceToPlayer;
                    nearestPlayerUnit = p_Unit;
                    
                }

                if (myTurret.upPlaneOn == false && myTurret.downPlaneOn == true && myTurret.upperPlane.transform.position.y <= p_Unit.transform.position.y) // lower plane // upwards shooting
                {
                    shortestDistance = distanceToPlayer;
                    nearestPlayerUnit = p_Unit;

                }

                if (myTurret.upPlaneOn == true && myTurret.downPlaneOn == true && myTurret.upperPlane.position.y >= p_Unit.transform.position.y && myTurret.lowerPlane.position.y <= p_Unit.transform.position.y) // within two planes
                {
                    shortestDistance = distanceToPlayer;
                    nearestPlayerUnit = p_Unit;

                }

                // this enemy is the closest

            }
            Debug.Log("Check Target1");
            if (nearestPlayerUnit != null && shortestDistance < range)
            {
                target = nearestPlayerUnit.transform;
                Debug.Log("Check Target2");


            }
            else
            {
                target = null;
            }




        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        //  Gizmos.color = Color.yellow;

    }
}
