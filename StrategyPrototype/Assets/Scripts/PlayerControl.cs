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
    [SerializeField]
    private GameObject[] units;
    public GameObject destinationPrefab;



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


                if (Input.GetMouseButton(0))
                {
                    
                    axis.SetActive(true);
                    // myTransform.Translate(new Vector3(0f, 0.1f * Input.GetAxis("Mouse Y"), 0f));

                    

                    if (Input.GetAxis("Mouse ScrollWheel") < 0)
                    {
                        myTransform.Translate(new Vector3(0f, 2f, 0f) * Input.GetAxis("Mouse ScrollWheel"));
                    }
                    if (Input.GetAxis("Mouse ScrollWheel") > 0)
                    {
                        myTransform.Translate(new Vector3(0f, -2f, 0f) * -Input.GetAxis("Mouse ScrollWheel"));
                    }

                    

                }
                else if (Input.GetMouseButtonUp(0)) ///////////////////////////////////////////////////////////////////////////////////////////////
                {
                  // destinationPrefab = Instantiate(destinationPrefab, transform.position, Quaternion.identity) as GameObject;

                    for (int i = 0; i < units.Length; i++)
                    {
                        if (units[i].GetComponent<PlayerUnitMove>().selected == true)
                        {
                            if (units[i].GetComponent<PlayerUnitMove>().myTargetPos == null)
                            {
                                
                                    units[i].GetComponent<PlayerUnitMove>().myTargetPos = Instantiate(destinationPrefab, pos = new Vector3(transform.position.x +(1.5f*i),transform.position.y,transform.position.z), Quaternion.identity);
                                
                                
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

                if (Input.GetMouseButtonDown(1))    // Deselects all selected units
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
