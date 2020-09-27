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
    public float resetVisTimerMax = 5f;
    public float resetVisTimer = 5f;


    public Renderer myMeshRend;

    
    

    // Update is called once per frame
    void Update()
    {
        myMeshRend.enabled = isVisible;

        if (isVisible)
        {


        }

    }

    public void resetVis()
    {
        isVisible = false;
        resetVisTimer = resetVisTimerMax;
    }
}
