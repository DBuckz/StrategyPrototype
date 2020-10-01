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
    public GameObject finalDeathEffect;

    [Header("Misc")]
    public float timer = 3f;
   // private IEnumerator coroutine;
    
    

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
        Invoke("DestroyObject", timer);
    }


    public void DestroyObject()
    {
        Instantiate(finalDeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
