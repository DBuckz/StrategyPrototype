using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool isVisible = false;

    public Renderer myMeshRend;
    

    // Update is called once per frame
    void Update()
    {
        myMeshRend.enabled = isVisible;
    }
}
