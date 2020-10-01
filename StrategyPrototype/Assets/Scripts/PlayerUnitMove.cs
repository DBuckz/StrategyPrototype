using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
        myVectorY = GetComponent<Vector3>();
    }

    private Vector3 pos;
    private Transform myTransform;  // from
    public GameObject myTargetPos;  // to 
  //  public GameObject movePos;
    private Vector3 myVectorY;
    private Vector3 myVectorDir;
    public bool selected;
    public GameObject[] selectInds;
    public float speed = 2f;
    public float rotSpeed;




    // Update is called once per frame
    void FixedUpdate()
    {
      //  Debug.Log("Cur "+selected);
        if (myTargetPos != null)
        {
            Debug.Log("Rotatus");
            //    myTransform.rotation = Quaternion.Lerp(myTransform.rotation,myTargetPos.gameObject.transform.rotation,speed * Time.deltaTime);
            //myTransform.Rotate(new Vector3(0,0,0));
            //upVec = Vector3.Lerp(upVec, target.up, UpDownSpeed * Time.deltaTime);

          //  myVectorDir = Vector3.Lerp(myVectorDir, myTargetPos.transform.position, rotSpeed * Time.deltaTime);
          //  myVectorY = Vector3.Lerp(myVectorY, myTargetPos.transform.up, rotSpeed * Time.deltaTime);



            
            //  myTransform.rotation = myVectorY
            myTransform.LookAt(new Vector3(myTargetPos.transform.position.x,myTransform.position.y,myTargetPos.transform.position.z));  // Placeholder Rotation
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
