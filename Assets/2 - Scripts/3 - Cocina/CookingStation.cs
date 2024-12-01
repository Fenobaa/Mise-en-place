using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingStation : MonoBehaviour
{

    private Cookable cookableObject;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.GetComponent<Cookable>())
        {
            Debug.Log("Cooking");
            cookableObject = other.GetComponent<Cookable>();
            cookableObject.StartCooking();
        }
    }
    


    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name +"w");
        if (other.GetComponent<Cookable>())
        {
            Debug.Log("Stop Cooking");
            cookableObject.StopCooking();
            cookableObject = null;
        }
    }
}
