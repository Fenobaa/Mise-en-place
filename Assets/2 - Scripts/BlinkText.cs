using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Animations;

public class BlinkText : MonoBehaviour
{
    public Animator Anims;

    private void Start()
    {
        
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Anims.SetBool("Click", true);
        }
    }
}
