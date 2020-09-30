using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image HealthBar;
    public Text healthText;
    public GameObject gameobject;
    public static int health;
    public static int maxHealth = 100;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        healthText.text = "Ship 1 Health: " + health;
        HealthBarFiller();

        if (health > maxHealth)
        {
            health = maxHealth; 
        }
    }

    void HealthBarFiller()
    {
        HealthBar.fillAmount = health / maxHealth;
    }

}