using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Opciones : MonoBehaviour
{
    public GameObject Botones;
    public GameObject Sonido;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerOPT"))
        {
            Botones.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "TriggerOPT")
        {
            Botones.SetActive(true);
        }
    }

}
