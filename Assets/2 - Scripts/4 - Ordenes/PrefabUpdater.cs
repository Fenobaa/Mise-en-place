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
    

    private Image ImageIngredient1;



    private Image imageIngredient2;



    private Image imageIngredient3;

    private TextMeshProUGUI timer;
    public int timerTime = 30;
    public float secondChecker = 1f;
    
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
        getComponentsInChildren();
        ActualizadorPlato();
        timer.text = timerTime.ToString();

    }

    private void Update()
    {
        if (gameManager.pauseTimers == false)
        {
            Inventory inventory = Inventory.instance;
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
                //Debug.Log(gameManager.MultiplicadordeAnsiedad);


                inventory.RemovePedido(this.gameObject);
                this.gameObject.transform.SetParent(null);
                Destroy(this.gameObject);

            }
        }
        
    }

    private void getComponentsInChildren()
    {
        
       TMPPlatoName = transform.Find("PlatoName").GetComponent<TextMeshProUGUI>();
       ImagePlato = transform.Find("PlatoImage").GetComponent<Image>();


       ImageIngredient1 = transform.Find("Ingredient1Image").GetComponent<Image>();


       imageIngredient2 = transform.Find("Ingredient2Image").GetComponent<Image>();

       
       imageIngredient3 = transform.Find("Ingredient3Image").GetComponent<Image>();

       timer = transform.Find("Timer").GetComponent<TextMeshProUGUI>();
    }
    private void ActualizadorPlato()
    {
        if (TMPPlatoName.text != thisPlatoScriptable.PlatoName)
        {
            ImagePlato.sprite = thisPlatoScriptable.PlatoSprite;
            TMPPlatoName.text = thisPlatoScriptable.PlatoName;
        }
        if (ImageIngredient1.sprite != thisPlatoScriptable.Ingredient1Sprite)
        {
            ImageIngredient1.sprite = thisPlatoScriptable.Ingredient1Sprite;
        }

        if (imageIngredient2.sprite != thisPlatoScriptable.Ingredient2Sprite && thisPlatoScriptable.Ingredient2Sprite != null)
        {
            imageIngredient2.sprite = thisPlatoScriptable.Ingredient2Sprite;
            imageIngredient2.GameObject().SetActive(true);
        }

        if (imageIngredient3.sprite != thisPlatoScriptable.Ingredient3Sprite && thisPlatoScriptable.Ingredient3Sprite != null)
        {
            imageIngredient3.sprite = thisPlatoScriptable.Ingredient3Sprite;
            imageIngredient3.GameObject().SetActive(true);
        }
    }
    

}
