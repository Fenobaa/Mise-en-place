using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSoundDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<UsoCuchillo>())
        {
            Debug.Log(other.name);
            UsoCuchillo usoCuchillo = other.GetComponent<UsoCuchillo>();
            usoCuchillo.isOntriggerWall = true;
            Debug.Log(usoCuchillo.isOntriggerWall);

        }
       
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<UsoCuchillo>())
        {
            UsoCuchillo usoCuchillo = other.GetComponent<UsoCuchillo>();
            usoCuchillo.isOntriggerWall = false;
            Debug.Log(usoCuchillo.isOntriggerWall);
        }
    }
}
