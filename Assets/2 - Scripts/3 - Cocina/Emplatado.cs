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

    private bool used;

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
            if (used)
            {
                Destroy(ingredient);
            }

        }
        else if (ingredient.name == "ZucchiniCut(Clone)")
        {
            zapallo--;
            if (used)
            {
                Destroy(ingredient);
            }
        }
        else if (ingredient.name == "TomateCortado(Clone)")
        {
            tomate--;
            if (used)
            {
                Destroy(ingredient);
            }
        }
        else if (ingredient.name == "PotatoCut(Clone)")
        {
            papa--;
            if (used)
            {
                Destroy(ingredient);
            }
        }
        else if (ingredient.name == "NoodlePackage(Clone)")
        {
            spaghetti--;
            if (used)
            {
                Destroy(ingredient);
            }
        }
        else if (ingredient.name == "EggplantCut(Clone)")
        {
            berengena--;
            if (used)
            {
                Destroy(ingredient);
            }
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
                Debug.Log(animal);
            }
            else if (ingredient.name == "ZucchiniCut(Clone)")
            {
                zapallo++;
                Debug.Log(zapallo);
            }
            else if (ingredient.name == "TomateCortado(Clone)")
            {
                tomate++;
                Debug.Log(tomate);
            }
            else if (ingredient.name == "PotatoCut(Clone)")
            {
                papa++;
                Debug.Log(papa);
            }
            else if (ingredient.name == "EggplantCut(Clone)")
            {
                berengena++;
                Debug.Log(berengena);
            }
            else if (ingredient.name == "NoodlePackage(Clone)")
            {
                spaghetti++;
                Debug.Log(spaghetti);
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
            used = true;
            RemoveIngredient(currentIngredients.Find(x => x.name == "ZucchiniCut(Clone)"));
            RemoveIngredient(currentIngredients.Find(x => x.name == "TomateCortado(Clone)"));
            RemoveIngredient(currentIngredients.Find(x => x.name == "MEAT(Clone)"));
            
            if (newDish.GetComponent<Plato>() != null)
            {
                newDish.GetComponent<Plato>().thisPlato = platosSO[3];
            }
            else
            {
                newDish.AddComponent<Plato>();
                newDish.GetComponent<Plato>().thisPlato = platosSO[3];
            }

            used = false;
            DeleteOrder(newDish.GetComponent<Plato>().thisPlato);
            GameManager.instance.textAdvertencias.text = " ";
        }

        else if (berengena > 0 && tomate > 0 && zapallo > 0) //Ratatouille
        {
            GameObject newDish = Instantiate(dishes[0], whereInstanciate.position, Quaternion.identity);
            used = true;
            RemoveIngredient(currentIngredients.Find(x => x.name == "EggpantCut(Clone)"));
            RemoveIngredient(currentIngredients.Find(x => x.name == "TomateCortado(Clone)"));
            RemoveIngredient(currentIngredients.Find(x => x.name == "ZucchiniCut(Clone)"));
            if (newDish.GetComponent<Plato>() != null)
            {
                newDish.GetComponent<Plato>().thisPlato = platosSO[1];
            }
            else
            {
                newDish.AddComponent<Plato>();
                newDish.GetComponent<Plato>().thisPlato = platosSO[1];
            }
            used = false;
            DeleteOrder(newDish.GetComponent<Plato>().thisPlato);
            GameManager.instance.textAdvertencias.text = " ";
        }

        else if (spaghetti > 0 && tomate > 0 && animal > 0) //Spaghetti boloñesa
        {
            GameObject newDish = Instantiate(dishes[0], whereInstanciate.position, Quaternion.identity);
            used = true;
            RemoveIngredient(currentIngredients.Find(x => x.name == "NoodlePackage(Clone)"));
            RemoveIngredient(currentIngredients.Find(x => x.name == "TomateCortado(Clone)"));
            RemoveIngredient(currentIngredients.Find(x => x.name == "MEAT(Clone)"));

            if (newDish.GetComponent<Plato>() != null)
            {
                newDish.GetComponent<Plato>().thisPlato = platosSO[2];
            }
            else
            {
                newDish.AddComponent<Plato>();
                newDish.GetComponent<Plato>().thisPlato = platosSO[2];
            }
            used = false;
            DeleteOrder(newDish.GetComponent<Plato>().thisPlato);
            GameManager.instance.textAdvertencias.text = " ";
        }
        else if (papa > 0 && animal > 0) //Carne con pure
        {
            GameObject newDish = Instantiate(dishes[0], whereInstanciate.position, Quaternion.identity);
            used = true;
            RemoveIngredient(currentIngredients.Find(x => x.name == "MEAT(Clone)"));
            RemoveIngredient(currentIngredients.Find(x => x.name == "PotatoCut(Clone)"));

            if (newDish.GetComponent<Plato>() != null)
            {
                newDish.GetComponent<Plato>().thisPlato = platosSO[0];
            }
            else
            {
                newDish.AddComponent<Plato>();
                newDish.GetComponent<Plato>().thisPlato = platosSO[0];
            }
            used = false;
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
        Debug.Log("setaeliminando");
        Inventory inventory = Inventory.instance;
        
        foreach (GameObject panel in inventory.panelesPedidos)
        {
             PrefabUpdater prefabUpdater = panel.GetComponent<PrefabUpdater>();
             
            if (prefabUpdater.thisPlatoScriptable == platoSO)
            {
                Destroy(panel);
                inventory.RemovePedido(panel);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Draggable") && other.GetComponent<Cookable>())
        {
            Cookable cookable = other.GetComponent<Cookable>();
            if (cookable.currentState == Cookable.CookingState.Cooked)
            {
                AddIngredient(other.gameObject);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Draggable") && other.GetComponent<Cookable>())
        {
            Cookable cookable = other.GetComponent<Cookable>();
            if (cookable.currentState == Cookable.CookingState.Cooked)
            {
                RemoveIngredient(other.gameObject);
            }

        }
    }
}
