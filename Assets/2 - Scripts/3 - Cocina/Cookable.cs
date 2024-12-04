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
                break;
            case CookingState.Burned:
                objectRenderer.material.mainTexture = burnedTexture;
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

    public void StartCooking()
    {
        if (cookingCoroutine == null)
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