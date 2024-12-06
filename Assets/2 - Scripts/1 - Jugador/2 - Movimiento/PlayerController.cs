using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]

public class PlayerController : MonoBehaviour
{
    
    public Rigidbody rb;

    public float playerSpeed = 3f;

    public Animator Anim;

    private bool isGrounded;
    [SerializeField] public Vector3 checkPoint;
    
    public AudioSource audio1;

    public AudioSource audio2;
    
    public AudioSource audio3;

    [SerializeField] private List<AudioClip> clips;
    
    [SerializeField] private int audioSpawnTime; 
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

        if (GameManager.instance.matarJefe == true)
        {
            StartCoroutine(PlaySound());
        }
    }

    IEnumerator PlaySound()
    {
        int seleccion1 = Random.Range(0, clips.Count);
        audio1.clip =  clips[seleccion1];
        
        int seleccion2 = Random.Range(0, clips.Count);
        audio2.clip = clips[seleccion2];
        
        int seleccion3 = Random.Range(0, clips.Count);
        audio3.clip = clips[seleccion3];
        
        audio1.clip = clips[seleccion1];
        audio2.clip = clips[seleccion2];
        audio3.clip = clips[seleccion3];
        
        audio1.Play();
        audio2.Play();
        audio3.Play();
        yield return new WaitForSeconds(audioSpawnTime);
    }

    public void LoadCheckPoint()
    {
        transform.position = checkPoint;
    }

}