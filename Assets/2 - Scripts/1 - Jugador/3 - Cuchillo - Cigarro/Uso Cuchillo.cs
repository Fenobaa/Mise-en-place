using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsoCuchillo : MonoBehaviour
{
    private Cambiodeobjetos Cambio;
    
    public Animator Anim;

    private void Awake()
    {
        Cambio = FindObjectOfType<Cambiodeobjetos>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) //&& Cambio.Cuchillo.activeSelf == true)
        {
            Anim.SetTrigger("Stab");
        }
    }
}
