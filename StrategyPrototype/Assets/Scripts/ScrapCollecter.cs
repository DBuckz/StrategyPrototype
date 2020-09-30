using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrapCollecter : MonoBehaviour
{
    public static int ScrapCount = 0;
    public GameObject ScrapText;

    void Update()
    {
        ScrapText.GetComponent<Text>().text = "Scrap: " + ScrapCount;
    }

    void FixedUpdate()
    {
        ScrapCount ++;
    }
}
