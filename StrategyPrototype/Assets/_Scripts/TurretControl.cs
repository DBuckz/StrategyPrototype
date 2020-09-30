using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [Header("Gun Constraints")]
    public bool upPlaneOn = false;
    public bool downPlaneOn = false;

    public Transform upperPlane;
    public Transform lowerPlane;

    public PlayerLOS PlayerLOS;
    public EnemyLOS EnemyLOS;

    public Transform target;



    // Update is called once per frame
    void Update()
    {
        ReceiveTarget();
        if (target != null)
        {
            transform.LookAt(target.transform);
        }
        



    }


    public void ReceiveTarget()
    {

        if (PlayerLOS == true ^ EnemyLOS == true)   // either one but not both
        {
            if (PlayerLOS) target = PlayerLOS.target;

            if (EnemyLOS) target = EnemyLOS.target;
        }

    }

}
