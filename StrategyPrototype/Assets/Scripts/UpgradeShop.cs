using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShop : MonoBehaviour
{

    public bool buyDamage = false;
    bool buySpeed = false;
    bool buyHP = false;
    bool buyRepair = false;

    public static int gunDamage = 10;

    private int costD = 300;
    private int costS = 300;
    private int costH = 300;
    private int costR = 150;

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Bullet;
    public GameObject upgradeMenu;
    public GameObject Damage;
    public GameObject Speed;
    public GameObject MaxHealth;
    public GameObject Repair;

    void Start()
    {
        Player1.gameObject.GetComponent <Health> ();   
    }

    void Update()
    {

        if (upgradeMenu.activeInHierarchy)
        {
            Damage.GetComponent<Text>().text = "Damage Cost:" + costD;
            MaxHealth.GetComponent<Text>().text = "Max HP Cost:" + costH;
            Speed.GetComponent<Text>().text = "Speed Cost:" + costS;
            Repair.GetComponent<Text>().text = "Repair Cost:" + costR;
        }
        Shop();
    }

     public void Shop()
    {
        if (buyDamage)
        {
            if (ScrapCollecter.ScrapCount > costD)
            {
                gunDamage += 10;
                ScrapCollecter.ScrapCount -= costD;
                costD *= 2;
                Damage1();
                buyDamage = false;
            }
            else buyDamage = false;

        }

        if (buyHP)
        {
            if (ScrapCollecter.ScrapCount > costH)
            {
                Health.maxHealth += 500;
                ScrapCollecter.ScrapCount -= costH;
                costH *= 2;
                HP();
                buyHP = false;
            }
            else buyHP = false;
        }

        if (buySpeed)
        {
            if (ScrapCollecter.ScrapCount > costS)
            {
                // += 500;
                ScrapCollecter.ScrapCount -= costS;
                costS *= 2;
                Speed1();
                buySpeed = false;
            }
            else buySpeed = false;
        }

        if (buyRepair)
        {
            if (ScrapCollecter.ScrapCount > costR)
            {
                Health.health += 50;
                ScrapCollecter.ScrapCount -= costR;
                Repair1();
                buyRepair = false;
            }
            else buyRepair = false;
        }


     }

    public void Damage1()
    {
        buyDamage = true;
    }

    public void HP()
    {
        buyHP = !buyHP;
    }

    public void Speed1()
    {
        buySpeed = !buySpeed;
    }

    public void Repair1()
    {
        buyRepair = !buyRepair;
    }

}
