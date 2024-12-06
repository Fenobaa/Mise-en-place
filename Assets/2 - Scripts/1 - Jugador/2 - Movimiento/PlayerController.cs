using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rb;

    public float playerSpeed = 3f;

    public Animator Anim;

    private bool isGrounded;
    [SerializeField] public Vector3 checkPoint;


    void Awake()
    {
        if (rb != null)
        {
            rb.freezeRotation = true;
        }

        checkPoint = transform.position;
    }

    private void Update()
    {
        if (GameManager.instance.finalesComprobation == false)
        {
            float h = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
            float v = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;

            transform.Translate(h, 0, v);

            if(h != 0 || v != 0)
            {
                Anim.SetBool("Walking", true);
            }
            else
            {
                Anim.SetBool("Walking", false);
            }
        }
    }

    public void LoadCheckPoint()
    {
        transform.position = checkPoint;
    }

}