using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
    //    myPos = GetComponent<Vector3>();
    }
    Transform myTransform;
    Vector3 myPos;
    public float speed = 5f;
    public float lifetime = 5f;
    public int damage = 5;

    [Header("Effects")]
    public GameObject[] effects;

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position += transform.forward * speed * Time.deltaTime;

        lifetime -= 1 * Time.deltaTime;
        if (lifetime < 0) Destroy(gameObject);


    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.tag == "UnitPlayer" || collision.collider.tag == "UnitEnemy")
        {
            var targetHit = collision.collider.GetComponent<UnitStats>();

            targetHit.health -= damage;
            // Destroy(collision.collider.gameObject);

            if (effects != null)
            {
                for (int i = 0; i < effects.Length; i ++)
                {
                    Instantiate(effects[i],transform.position,Quaternion.identity);
                }
            }

            Destroy(gameObject);

        }

    }



}
