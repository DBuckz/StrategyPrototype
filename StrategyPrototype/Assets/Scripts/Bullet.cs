using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static int Damage = 20;
    public GameObject Player;
    public GameObject Player2;
    public GameObject Player3;

    private void Start()
    {
        Player.gameObject.GetComponent<Health>();
    }

    void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.tag == "Player")
            {
                Health.health -= 20;
            }
        
        Destroy(gameObject);
    }
}
