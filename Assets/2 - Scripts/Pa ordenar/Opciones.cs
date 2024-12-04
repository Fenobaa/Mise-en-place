using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.UI;

public class Opciones : MonoBehaviour
{
    public GameObject Panel;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerOPT"))
        {
            Panel.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "TriggerOPT")
        {
            Panel.SetActive(true);
        }
    }

}
