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


    // Update is called once per frame
    void Update()
    {
        PlayerUnitDetection();
        


    }

    
    void PlayerUnitDetection()
    {

        GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("UnitPlayer");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestPlayerUnit = null;

        foreach (GameObject p_Unit in playerUnits)
        {



            var direction = p_Unit.transform.position - transform.position;
            float distanceToPlayer = Vector3.Distance(transform.position, p_Unit.transform.position);

            RaycastHit hit;
            Debug.Log(distanceToPlayer);
            if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity) && distanceToPlayer < range)
            {
                Debug.DrawRay(transform.position, direction, Color.red);
            //    p_Unit.GetComponent<EnemyControl>().isVisible = true;
            }

            if (Physics.Raycast(transform.position, direction, out hit, range) && hit.collider.tag == "UnitPlayer")
            {

            }

            if (distanceToPlayer < shortestDistance)    // checks for closest AND visible
            {
                shortestDistance = distanceToPlayer;
                nearestPlayerUnit = p_Unit;   // this enemy is the closest

            }

            if (nearestPlayerUnit != null && shortestDistance < range)
            {
                target = nearestPlayerUnit.transform;

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
