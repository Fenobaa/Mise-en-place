using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Animations;

public class BlinkText : MonoBehaviour
{
    public Animator Anims;

    public GameObject Camara;
    public GameObject texto;

    private void Start()
    {
        Camara.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Anims.SetBool("Click", true);
            {
                Camara.SetActive(true);
                TIEMPO();
            }
        }
    }

    IEnumerator TIEMPO()
    {
        yield return new WaitForSeconds(1);
        
        texto.SetActive(false);
    }
}
