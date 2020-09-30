using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthShip3 : MonoBehaviour
{
    public Image HealthBar;
    public GameObject gameobject;
    public int health;
    public int maxHealth = 100;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        HealthBarFiller();

        if (health > 100)
        {
            health = maxHealth;
        }
    }

    void HealthBarFiller()
    {
        HealthBar.fillAmount = health / maxHealth;
    }

    void OnCollisonEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 20;
        }
    }
}