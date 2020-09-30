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

    private Vector3 pos;
    private Transform myTransform;
    public GameObject myTargetPos;
    public GameObject movePos;
    private Vector3 myVector;
    public bool selected;
    public GameObject[] selectInds;
    public float speed = 2f;

    // Update is called once per frame
    void FixedUpdate()
    {
      //  Debug.Log("Cur "+selected);
        if (myTargetPos != null)
        {
            myTransform.position = Vector3.MoveTowards(myTransform.position, myTargetPos.gameObject.transform.position, speed * Time.deltaTime);
        }



     // pos = Vector3.RotateTowards(myTransform,myTargetPos.GetComponent<Vector3>(),1,3);

    }

    private void OnMouseUp()
    {
        
        
    }

    public void SelectMe()
    {
        selected = true;
        for (int i = 0; i < selectInds.Length; i++)
        {
            selectInds[i].SetActive(true);
        }

    }

    public void DeselectMe()
    {
        selected = false;
        for (int i = 0; i < selectInds.Length; i++)
        {
            selectInds[i].SetActive(false);
        }

    }

    
}
