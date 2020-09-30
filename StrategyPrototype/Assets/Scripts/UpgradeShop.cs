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

    private int costD = 3000;
    private int costS = 3000;
    private int costH = 3000;
    private int costR = 1500;

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

    void Shop()
    {
        if (buyDamage)
        {
            if (ScrapCollecter.ScrapCount > costD)
            {
                gunDamage += 10;
                ScrapCollecter.ScrapCount -= costD;
                costD *= 2;
                Damage();
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
                Health.maxHealth += 500;
                ScrapCollecter.ScrapCount -= costS;
                costS *= 2;
                Speed();
                buyHP = false;
            }
            else buyHP = false;
        }

        if (buyRepair)
        {
            if (ScrapCollecter.ScrapCount > costR)
            {
                Health.maxHealth += 500;
                ScrapCollecter.ScrapCount -= costR;
                costR *= 2;
                Repair();
                buyHP = false;
            }
            else buyHP = false;
        }

        void Damage()
        {
            buyDamage = true;
        }

        void HP()
        {
            buyHP = !buyHP;
        }

        void Speed()
        {
            buySpeed = !buySpeed;
        }

        void Repair()
        {
            buySpeed = !buySpeed;
        }

    }
}
