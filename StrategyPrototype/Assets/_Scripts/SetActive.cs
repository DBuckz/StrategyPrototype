using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{

    public GameObject myObject;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "UnitPlayer") myObject.SetActive(true);

    }
}
