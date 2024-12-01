using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class PrefabUpdater : MonoBehaviour
{
    public PlatosScriptable thisPlatoScriptable;

    private TextMeshProUGUI TMPPlatoName;
    private Image ImagePlato;
    
    private TextMeshProUGUI TMPIngredient1;
    private Image ImageIngredient1;
    private Image Ingredient1Checkmark;

    private TextMeshProUGUI TMPIngredient2;
    private Image imageIngredient2;
    private Image ingredient2Checkmark;

    private TextMeshProUGUI tMPIngredient3;
    private Image imageIngredient3;
    private Image ingredient3Checkmark;
    
    private TextMeshProUGUI timer;
    public int timerTime = 30;
    public float secondChecker = 1f;
    
    private GameManager gameManager;

    private void Start()
    {
        timerTime = 160;
        gameManager = GameManager.instance;
        getComponentsInChildren();
        ActualizadorPlato();
        timer.text = timerTime.ToString();

    }

    private void Update()
    {
        if (gameManager.pauseTimers == false)
        {
            secondChecker -= Time.deltaTime;

            if (secondChecker <= 0)
            {
                timerTime--;
                timer.text = timerTime.ToString();
            
                secondChecker = 1f;
            }

            if (timerTime == 0)
            {
                gameManager.MultiplicadordeAnsiedad += 0.1f;
                Debug.Log(gameManager.MultiplicadordeAnsiedad);
                Destroy(this.gameObject);
            }
        }
        
    }

    private void getComponentsInChildren()
    {
        
       TMPPlatoName = transform.Find("PlatoName").GetComponent<TextMeshProUGUI>();
       ImagePlato = transform.Find("PlatoImage").GetComponent<Image>();

       TMPIngredient1 = transform.Find("Ingredient1").GetComponent<TextMeshProUGUI>();
       ImageIngredient1 = transform.Find("Ingredient1Image").GetComponent<Image>();
       Ingredient1Checkmark = transform.Find("Ingredient1Checkmark").GetComponent<Image>();

       TMPIngredient2 = transform.Find("Ingredient2").GetComponent<TextMeshProUGUI>();
       imageIngredient2 = transform.Find("Ingredient2Image").GetComponent<Image>();
       ingredient2Checkmark = transform.Find("Ingredient2Checkmark").GetComponent<Image>();

       tMPIngredient3 = transform.Find("Ingredient3").GetComponent<TextMeshProUGUI>();
       imageIngredient3 = transform.Find("Ingredient3Image").GetComponent<Image>();
       ingredient3Checkmark = transform.Find("Ingredient3Checkmark").GetComponent<Image>();

       timer = transform.Find("Timer").GetComponent<TextMeshProUGUI>();
    }
    private void ActualizadorPlato()
    {
        if (TMPPlatoName.text != thisPlatoScriptable.PlatoName)
        {
            ImagePlato.sprite = thisPlatoScriptable.PlatoSprite;
            TMPPlatoName.text = thisPlatoScriptable.PlatoName;
        }
        if (TMPIngredient1.text != thisPlatoScriptable.Ingredient1)
        {
            ImageIngredient1.sprite = thisPlatoScriptable.Ingredient1Sprite;
            TMPIngredient1.text = thisPlatoScriptable.Ingredient1;
        }

        if (TMPIngredient2.text != thisPlatoScriptable.Ingredient2 && thisPlatoScriptable.Ingredient2 != null)
        {
            
            imageIngredient2.sprite = thisPlatoScriptable.Ingredient2Sprite;
            imageIngredient2.GameObject().SetActive(true);
            TMPIngredient2.text = thisPlatoScriptable.Ingredient2;
            TMPIngredient2.gameObject.SetActive(true);
            ingredient2Checkmark.GameObject().SetActive(true);
        }

        if (tMPIngredient3.text != thisPlatoScriptable.Ingredient3 && thisPlatoScriptable.Ingredient3 != null)
        {
            imageIngredient3.sprite = thisPlatoScriptable.Ingredient3Sprite;
            imageIngredient3.GameObject().SetActive(true);
            tMPIngredient3.text = thisPlatoScriptable.Ingredient3;
            tMPIngredient3.gameObject.SetActive(true);
            ingredient3Checkmark.GameObject().SetActive(true);
        }
    }
    

}
