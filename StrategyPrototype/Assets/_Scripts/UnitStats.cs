using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    [Header("Unit Stats")]

    public int health = 10;
    public bool isDead = false;

    [Header("Death Effects")]
    public GameObject[] effects;


    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            UnitDestroyed();
        }

    }

    public void UnitDestroyed()
    {
        if (effects != null)
        {
            for (int i = 0; i < effects.Length; i++)
            {
                Instantiate(effects[i],transform.position,Quaternion.identity);
            }
        }
        isDead = true;
        Destroy(gameObject);    // Will be put delayed further up, if death animations in place
    }
}
