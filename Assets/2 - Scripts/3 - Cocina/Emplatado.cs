using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Emplatado : MonoBehaviour
{
    public GameObject[] dishes;
    public PlatosScriptable[] platosSO;
    
    public List<GameObject> currentIngredients;
    
    public Transform whereInstanciate;
    
    [Header("CONTADOR INGREDIENTES")]
    [Space(15)]
    public int totalIngredients;
    [Space(10)]
    //Zapallo Italiano Relleno
    public int animal;
    public int zapallo;
    public int tomate;
    [Space(10)] 
    public int papa;
    public int spaghetti;
    public int berengena;
    

    void AddIngredient(GameObject ingredient)
    {
        currentIngredients.Add(ingredient);
        
        CheckIngredients();
    }

    void RemoveIngredient(GameObject ingredient)
    {
        if (ingredient.name == "MEAT(Clone)")
        {
            animal--;
        }
        else if (ingredient.name == "ZucchiniCut(Clone)")
        {
            zapallo--;
        }
        else if (ingredient.name == "TomateCortado(Clone)")
        {
            tomate--;
        }
        else if (ingredient.name == "PotatoCut(Clone)")
        {
            papa--;
        }
        else if (ingredient.name == "NoodlePackage(Clone)")
        {
            spaghetti--;
        }
        else if (ingredient.name == "EggplantCut(Clone)")
        {
            berengena--;
        }
        totalIngredients = animal + zapallo + tomate + papa + berengena + spaghetti;
        
        currentIngredients.Remove(ingredient);
    }
    
    void CheckIngredients()
    {
        foreach (GameObject ingredient in currentIngredients)
        {
            if (ingredient.name == "MEAT(Clone)")
            {
                animal++;
            }
            else if (ingredient.name == "ZucchiniCut(Clone)")
            {
                zapallo++;
            }
            else if (ingredient.name == "TomateCortado(Clone)")
            {
                tomate++;
            }
            else if (ingredient.name == "PotatoCut(Clone)")
            {
                papa++;
            }
            else if (ingredient.name == "EggplantCut(Clone)")
            {
                berengena++;
            }
            else if (ingredient.name == "NoodlePackage(Clone)")
            {
                spaghetti++;
            }
        }
        
        totalIngredients = animal + zapallo + tomate + papa + berengena + spaghetti;

        PrepararPlato();
    }

    void PrepararPlato()
    {
        if (animal > 0 && zapallo > 0 && tomate > 0) // Zapallo Italiano
        {
            GameObject newDish = Instantiate(dishes[0], whereInstanciate.position, Quaternion.identity);
            RemoveIngredient(gameObject);
            if (newDish.GetComponent<Plato>() != null)
            {
                newDish.GetComponent<Plato>().thisPlato = platosSO[0];
            }
            else
            {
                newDish.AddComponent<Plato>();
                newDish.GetComponent<Plato>().thisPlato = platosSO[0];
            }
            
            DeleteOrder(newDish.GetComponent<Plato>().thisPlato);
            GameManager.instance.textAdvertencias.text = " ";
        }

        else if (berengena > 0 && tomate > 0 && zapallo > 0)
        {
            RemoveIngredient(gameObject);
            GameObject newDish = Instantiate(dishes[0], whereInstanciate.position, Quaternion.identity);
            if (newDish.GetComponent<Plato>() != null)
            {
                newDish.GetComponent<Plato>().thisPlato = platosSO[0];
            }
            else
            {
                newDish.AddComponent<Plato>();
                newDish.GetComponent<Plato>().thisPlato = platosSO[0];
            }
            
            DeleteOrder(newDish.GetComponent<Plato>().thisPlato);
            GameManager.instance.textAdvertencias.text = " ";
        }

        else if (spaghetti > 0 && tomate > 0 && animal > 0)
        {
            RemoveIngredient(gameObject);
            GameObject newDish = Instantiate(dishes[0], whereInstanciate.position, Quaternion.identity);
            if (newDish.GetComponent<Plato>() != null)
            {
                newDish.GetComponent<Plato>().thisPlato = platosSO[0];
            }
            else
            {
                newDish.AddComponent<Plato>();
                newDish.GetComponent<Plato>().thisPlato = platosSO[0];
            }
            
            DeleteOrder(newDish.GetComponent<Plato>().thisPlato);
            GameManager.instance.textAdvertencias.text = " ";
        }
        else if (papa > 0 && animal > 0)
        {
            RemoveIngredient(gameObject);
            GameObject newDish = Instantiate(dishes[0], whereInstanciate.position, Quaternion.identity);
            if (newDish.GetComponent<Plato>() != null)
            {
                newDish.GetComponent<Plato>().thisPlato = platosSO[0];
            }
            else
            {
                newDish.AddComponent<Plato>();
                newDish.GetComponent<Plato>().thisPlato = platosSO[0];
            }
            
            DeleteOrder(newDish.GetComponent<Plato>().thisPlato);
            GameManager.instance.textAdvertencias.text = " ";
        }
        else if (totalIngredients > 0)
        {
            GameManager.instance.textAdvertencias.text = "No hay suficientes ingredientes";
        }
    }

    void DeleteOrder(PlatosScriptable platoSO)
    {
        Inventory inventory = Inventory.instance;
        
        foreach (GameObject panel in inventory.panelesPedidos)
        {
            if (panel.GetComponent<PlatosScriptable>() == platoSO)
            {
                Destroy(panel);
                inventory.RemovePedido(panel);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Draggable"))
        {
            AddIngredient(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Draggable"))
        {
            RemoveIngredient(other.gameObject);
        }
    }
}
