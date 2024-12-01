using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenStation : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Cookable cookable = other.GetComponent<Cookable>();
        if (cookable != null)
        {
            cookable.StartCooking();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Cookable cookable = other.GetComponent<Cookable>();
        if (cookable != null)
        {
            cookable.StopCooking();
        }
    }
}
