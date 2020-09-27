using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [Header("Weapon Settings")]
    public GameObject projectile;
    public GameObject firepoint;
    public TurretControl myTurret;
    public float fireRate = 10f;
    private float cooldown = 0f;

    [Header("Weapon Effects")]
    public GameObject[] myEffects;

    // Update is called once per frame
    void FixedUpdate()
    {
        cooldown += 1f * Time.deltaTime;
        if (cooldown > 1 / fireRate && myTurret.target == true)
        {
            if (myEffects != null)  // Particle Effects etc....
            {
                for (int i = 0; i < myEffects.Length; i++)
                {
                    Instantiate(myEffects[i],firepoint.transform.position,firepoint.transform.rotation);
                }
            }

            Instantiate(projectile,firepoint.transform.position, firepoint.transform.rotation);
            cooldown = 0f;
        }
    }

    

}
