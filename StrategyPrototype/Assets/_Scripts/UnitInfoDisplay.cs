using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInfoDisplay : MonoBehaviour
{
    private void Awake()
    {
        getCamera = GameObject.Find("CameraControl");

        if (uiSettings) getButton = GetComponent<Button>();
    }
    private GameObject getCamera;
    public Slider healthSliderDisplay;
    public UnitStats getUnitHealth;
    public PlayerUnitMove getSelect;
    public Button getButton;
    public string keyShortcut;
    [Header("Other Settings")]
    [SerializeField]
    private bool lookAtCam = true;
    [SerializeField]
    private bool uiSettings = false;
    // Update is called once per frame
    void Update()
    {

        if (uiSettings)
        {
            forUI();
            selectShortcut(keyShortcut);
        }
            


        displayInfo();
    }

    void displayInfo()
    {
        if (lookAtCam)
        {
            transform.LookAt(getCamera.transform.position);
        }
        
        healthSliderDisplay.value = getUnitHealth.health;

        if (getUnitHealth.isDead)
        {
            getButton.image.color = Color.red;
        }
    }


    void forUI()
    {
        if (getSelect.selected)
        {
            getButton.image.color = Color.green;
        }
        else
        {
            getButton.image.color = Color.grey;
        }
    }

    void selectShortcut(string key)
    {

        if (Input.GetKeyDown(key) && getSelect.selected != true)
        {
            getSelect.SelectMe();
        }
        else if (Input.GetKeyDown(key) && getSelect.selected)
        {
            getSelect.DeselectMe();
        }

    }
}
