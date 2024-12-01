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

    private float timeInTrigger = 0f;
    private Renderer objectRenderer;

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
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CookingZone"))
        {
            StartCooking();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CookingZone"))
        {
            StopCooking();
        }
    }

    public void StartCooking()
    {
        StartCoroutine(CookingRoutine());
    }

    public void StopCooking()
    {
        StopCoroutine(CookingRoutine());
    }

    private IEnumerator CookingRoutine()
    {
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