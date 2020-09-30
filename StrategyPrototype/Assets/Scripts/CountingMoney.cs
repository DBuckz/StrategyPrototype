using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountingMoney : MonoBehaviour
{
    public GameObject moneyText;
    public static int money;


    void Update()
    {
        moneyText.GetComponent<Text>().text = "Money:" + money;
    }
}
