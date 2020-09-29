using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    private Camera cam;
    public Transform myTransform;
    private Vector3 pos;
    public LayerMask mask = 8;
    public GameObject axis;
    public GameObject YaxisControl;
    public GameObject unitOptions;
    [SerializeField]
    private GameObject[] units;
    public GameObject destinationPrefab;

    public float mouseSensY = 5f;
    private float moveUD;
    

    // Update is called once per frame
    void Update()
    {
        pos = new Vector3();
        units = GameObject.FindGameObjectsWithTag("UnitPlayer");
        //   myTransform.position = cam.ScreenToWorldPoint(Input.mousePosition);
        var vert = Input.GetAxis("Mouse Y");
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            

            if (hit.collider.tag == "CursorHitCol")     // hits cursor nav plane
            {


                if (Input.GetMouseButton(1))    // Move Unit X,Z
                {
                    
                    axis.SetActive(true);
                    
                    Cursor.lockState = CursorLockMode.Confined;
                    YaxisControl.SetActive(true);               // Activates an invisible plane, to allow Y level control without relying on terrain raycast to register
                    moveUD = Input.GetAxis("Mouse Y") * mouseSensY * Time.deltaTime;
                    myTransform.Translate(new Vector3(0,moveUD,0));
                
                    

                }
                else if (Input.GetMouseButtonUp(1)) // Move Unit Y
                {
                    
                    Cursor.lockState = CursorLockMode.None;
                    YaxisControl.SetActive(false);

                    for (int i = 0; i < units.Length; i++) // Set Unit Positions
                    {
                        if (units[i].GetComponent<PlayerUnitMove>().selected == true) 
                        {
                            if (units[i].GetComponent<PlayerUnitMove>().myTargetPos == null)
                            {
                                
                                    units[i].GetComponent<PlayerUnitMove>().myTargetPos = Instantiate(destinationPrefab, pos = new Vector3(transform.position.x +(1.5f*i-1.5f),transform.position.y,transform.position.z), Quaternion.identity);
                                
                                
                            }
                            else    // Moves destination instead of destroy & replace
                            {
                                units[i].GetComponent<PlayerUnitMove>().myTargetPos.GetComponent<Transform>().position = transform.position;
                            }
                            
                        }
                    }
                }
                else   // Deselect
                {
                    axis.SetActive(false);
                    
                    myTransform.position = hit.point;
                }

                if (Input.GetMouseButtonDown(0))    // Deselects all selected units
                {
                  units = GameObject.FindGameObjectsWithTag("UnitPlayer");

                    for (int i = 0; i < units.Length; i++)
                    {
                        units[i].GetComponent<PlayerUnitMove>().DeselectMe();
                    }
                }

            }
            
        }

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1<<9))       // Ray specifically to select and can pass through base nav plane
        {
            if (hit.collider.tag == "UnitPlayer" && Input.GetMouseButtonDown(0))
            {
                hit.collider.GetComponent<PlayerUnitMove>().SelectMe(); // Runs function SelectMe in PlayerUnitMove
            }
        }

        #region Middle Click Options

        if (Input.GetMouseButtonDown(2))
        {
            unitOptions.SetActive(true);
        }
        if (Input.GetMouseButtonUp(2))
        {
            unitOptions.SetActive(false);
        }

        #endregion


    }

    #region

    private void OnGUI()
    {
        /*

        Vector3 point = new Vector3();
        Vector2 mousePos = new Vector2();
        Event curEvent = Event.current;

    */

    }

    #endregion
}
