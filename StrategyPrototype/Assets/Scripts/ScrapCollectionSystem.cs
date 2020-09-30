using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapCollectionSystem : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ScrapCollecter.ScrapCount += 10000;

            Destroy(gameObject);
        }

    }
}
