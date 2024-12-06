using System;
using UnityEngine;
using System.Collections;

public class Cookable : MonoBehaviour
{
    public enum CookingState
    {
        Raw,
        Cooked,
        Burned
    }

    public CookingState currentState = CookingState.Raw;
    public float cookingTime = 5f; // Tiempo para cocinarse completamente
    public float burningTime = 10f; // Tiempo para quemarse después de cocinarse

    public Texture rawTexture;
    public Texture cookedTexture;
    public Texture burnedTexture;

    private Coroutine cookingCoroutine;
    private float timeInTrigger = 0f;
    private Renderer objectRenderer;

    private bool isCooking = false;
    private bool alreadyCooking = false;

    
    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        UpdateTexture();
    }

    private void UpdateTexture()
    {
        switch (currentState)
        {
            case CookingState.Raw:
                objectRenderer.material.mainTexture = rawTexture;
                break;
            case CookingState.Cooked:
                objectRenderer.material.mainTexture = cookedTexture;
                CheckingCookedTextureChange();
                break;
            case CookingState.Burned:
                objectRenderer.material.mainTexture = burnedTexture; 
                CheckingBurnedTextureChange();
                isCooking = false;
                break;
        }
    }
    
    private void Update()
    {
        if (GameManager.instance.pauseTimers == true )
        {
            if (cookingCoroutine != null)
            {
                StopCooking();
                alreadyCooking = false;
            }
            
        }
        else if (isCooking == true && GameManager.instance.pauseTimers == false )
        {
            if (alreadyCooking == false)
            {
                StartCooking();
                alreadyCooking = true;
            }
        }

    }

    public void CheckingCookedTextureChange()
    {
        if (this.gameObject.name =="PotatoCut(Clone)")
        {
            Transform child0 = transform.GetChild(0); 
            Renderer childRenderer0 = child0.GetComponent<Renderer>(); 
            childRenderer0.material.mainTexture = cookedTexture;
                    
            Transform child1 = transform.GetChild(1); 
            Renderer childRenderer1 = child1.GetComponent<Renderer>(); 
            childRenderer1.material.mainTexture = cookedTexture;
                    
            Transform child2 = transform.GetChild(2); 
            Renderer childRenderer2 = child2.GetComponent<Renderer>(); 
            childRenderer2.material.mainTexture = cookedTexture;
                    
            Transform child3 = transform.GetChild(3); 
            Renderer childRenderer3 = child3.GetComponent<Renderer>(); 
            childRenderer3.material.mainTexture = cookedTexture;
        }
        
    }

    public void CheckingBurnedTextureChange()
    {
        if (this.gameObject.name =="PotatoCut(Clone)")
        {
            Transform child0 = transform.GetChild(0); 
            Renderer childRenderer0 = child0.GetComponent<Renderer>(); 
            childRenderer0.material.mainTexture = burnedTexture;
                    
            Transform child1 = transform.GetChild(1); 
            Renderer childRenderer1 = child1.GetComponent<Renderer>(); 
            childRenderer1.material.mainTexture = burnedTexture;
                    
            Transform child2 = transform.GetChild(2); 
            Renderer childRenderer2 = child2.GetComponent<Renderer>(); 
            childRenderer2.material.mainTexture = burnedTexture;
                    
            Transform child3 = transform.GetChild(3); 
            Renderer childRenderer3 = child3.GetComponent<Renderer>(); 
            childRenderer3.material.mainTexture = burnedTexture;
        }
    }
    
    public void StartCooking()
    {
        if (cookingCoroutine == null && this.gameObject.transform.parent.name != "PotatoCut(Clone)")
        {
            cookingCoroutine = StartCoroutine(CookingRoutine());
        }
    }

    public void StopCooking()
    {
        if (cookingCoroutine != null)
        {
            StopCoroutine(cookingCoroutine);
            cookingCoroutine = null;
        }
    }

    private IEnumerator CookingRoutine()
    {
        isCooking = true;
        while (true)
        {
            timeInTrigger += Time.deltaTime;
            if (timeInTrigger >= burningTime)
            {
                currentState = CookingState.Burned;
                Debug.Log("El objeto está quemado.");
            }
            else if (timeInTrigger >= cookingTime)
            {
                currentState = CookingState.Cooked;
                Debug.Log("El objeto está cocido.");
            }
            UpdateTexture();
            yield return null;
        }
    }
    
    
}