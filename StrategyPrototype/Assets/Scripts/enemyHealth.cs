using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float MaxHealth = 100;
    public float CurrentHealth;
    public GameObject ScrapSpawn;
    public GameObject scrapPrefab;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            CurrentHealth -= 20;
        }
    }

    private void Update()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(ScrapSpawn);
            Instantiate (scrapPrefab,transform.position, Quaternion.identity);
        }
    }
}