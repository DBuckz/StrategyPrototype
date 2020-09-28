using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("InvokeDestroySelf",timer);
    }

    public float timer = 5f;

    public void InvokeDestroySelf()
    {
        Destroy(gameObject);
    }
}
