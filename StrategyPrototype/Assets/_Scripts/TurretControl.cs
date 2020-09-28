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

    public PlayerLOS PlayerControl;
    public EnemyLOS EnemyControl;

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

        if (PlayerControl == true ^ EnemyControl == true)   // either one but not both
        {
            if (PlayerControl) target = PlayerControl.target;

            if (EnemyControl) target = EnemyControl.target;
        }

    }

}
