using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panadero : MonoBehaviour
{
    public GameObject breadPrefab;
    private float cookingTime = 3;

    private void Start()
    {
        StartTimerAgain();
    }

    void StartTimerAgain()
    {
        StartCoroutine(BreadTimer());
    }

    private IEnumerator BreadTimer()
    {

        yield return new WaitForSeconds(cookingTime);
        Instantiate(breadPrefab, transform.position, Quaternion.identity);
        StartTimerAgain();
        yield return null;
        
    }
}
