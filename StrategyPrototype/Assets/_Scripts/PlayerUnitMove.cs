using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }


    private Transform myTransform;
    public GameObject myTargetPos;
    public GameObject movePos;
    private Vector3 myVector;
    public bool selected;
    public float speed = 2f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("Cur "+selected);
        myTransform.position = Vector3.MoveTowards(myTransform.position, myTargetPos.gameObject.transform.position, speed * Time.deltaTime);

    }

    private void OnMouseUp()
    {
        
        
    }

    public void SelectMe()
    {
        selected = true;
        Debug.Log(selected);
    }

    public void DeselectMe()
    {
        selected = false;
        Debug.Log(selected);
    }

    
}
