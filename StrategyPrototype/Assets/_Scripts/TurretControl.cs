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

    public GameObject target;

    // Update is called once per frame
    void Update()
    {
        
    }
}
