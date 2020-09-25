using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject projectile;
    public float fireRate;
    public float coolDown;
    // Update is called once per frame
    void FixedUpdate()
    {
        coolDown += coolDown * Time.deltaTime;
        if (coolDown > 1 / fireRate)
        {
           // coolDown = 
        }
    }

    

}
