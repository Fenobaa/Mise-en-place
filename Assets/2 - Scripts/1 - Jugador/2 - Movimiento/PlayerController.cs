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

    private bool corroutineRunning = false;
    public List<AudioClip> clips;
    
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
        if (GameManager.instance.matarJefe == true && corroutineRunning == false)
        {
            corroutineRunning = true;
            StartCoroutine(PlaySound());
        }
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

    IEnumerator PlaySound()
    {
        int seleccion1 = Random.Range(0, clips.Count);
        AudioClip clip1 = clips[seleccion1];
        AudioScript.Instance.ReplaceSFXClip(clip1);
        AudioScript.Instance.PlaySFX(clip1);
        Debug.Log("sereproduce");

        yield return new WaitForSeconds(2f);

        int seleccion2 = Random.Range(0, clips.Count);
        AudioClip clip2 = clips[seleccion2];
        AudioScript.Instance.ReplaceSFXClip(clip2);
        AudioScript.Instance.PlaySFX(clip2);

        yield return new WaitForSeconds(2f);

        int seleccion3 = Random.Range(0, clips.Count);
        AudioClip clip3 = clips[seleccion3];
        AudioScript.Instance.ReplaceSFXClip(clip3);
        AudioScript.Instance.PlaySFX(clip3);
 
        yield return new WaitForSeconds(audioSpawnTime);
        corroutineRunning = false;
    }

    public void LoadCheckPoint()
    {
        transform.position = checkPoint;
    }

}