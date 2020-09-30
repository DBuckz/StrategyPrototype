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
        Visibility();
    }

    public void resetVis()
    {
        isVisible = false;
        resetVisTimer = resetVisTimerMax;
    }

    public void Visibility()
    {
        myMeshRend.enabled = isVisible;
/*
        if (isVisible)
        {
            resetVisTimer -= 1 * Time.deltaTime;

            if (resetVisTimer <= 0)
            {
                isVisible = false;
                resetVisTimer = resetVisTimerMax;
            }
        }
        else
        {
            resetVisTimer = resetVisTimerMax;
        }
        */
    }
    
}
