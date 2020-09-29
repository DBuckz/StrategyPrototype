using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInfoDisplay : MonoBehaviour
{
    private void Awake()
    {
        getCamera = GameObject.Find("CameraControl");
    }
    private GameObject getCamera;
    public Slider healthSliderDisplay;
    public UnitStats getUnitHealth;

    // Update is called once per frame
    void Update()
    {
        displayInfo();
    }

    void displayInfo()
    {
        transform.LookAt(getCamera.transform.position);
        healthSliderDisplay.value = getUnitHealth.health;
    }
}
