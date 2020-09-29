using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        myPos = GetComponent<Vector3>();
        myTrans = GetComponent<Transform>();
    //    transform.position = new Vector3(0,0,0);
    }
    private Transform myTrans;
    public Vector3 myPos;
    public float camSpeed = 10f;
    private float xMove, yMove, zMove;

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxis("Horizontal") * camSpeed * Time.deltaTime;
        zMove = Input.GetAxis("Vertical") * camSpeed * Time.deltaTime;

        yMove = Input.GetAxis("Height") * camSpeed * Time.deltaTime;

        float x = transform.position.x;
        float z = transform.position.z;

        if (xMove != 0)
        {
            transform.Translate(xMove, 0, 0);
        }

        if (zMove != 0)
        {
            transform.Translate(0, 0, zMove);
        }

        if (yMove != 0)
        {
            transform.Translate(0,yMove,0);
        }
    }
}
