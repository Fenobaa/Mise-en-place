using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CutStation : MonoBehaviour
{
    public bool canInteract;
    
    public List<GameObject> addedIngredients;
    public GameObject[] slicedIngredients;
    [SerializeField] GameObject currentSlicedIngredient = null; // Referencia al plato instanciado
    
    public Transform spawnPoint;
    [SerializeField] int tomateCount;
    [SerializeField] int animalCount;
    [SerializeField] int berengenaCount;
    [SerializeField] int papaCount;
    [SerializeField] int zapalloCount;
    [SerializeField] int fideosCount;
    private void Start()
    {
        if (slicedIngredients.Length == 0)
        {
            Debug.LogError("Can't find the sliced ingredients");
        }
        
        addedIngredients.Clear();

        tomateCount = 0;
        animalCount = 0;
        berengenaCount = 0;
        papaCount = 0;
        zapalloCount = 0;
        fideosCount = 0;
        
        
        canInteract = false;
    }
    
    private void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && addedIngredients.Count > 0)
            {
                if (tomateCount > 0) 
                {
                    currentSlicedIngredient = Instantiate(slicedIngredients[0], spawnPoint.transform.position, Quaternion.identity);
                    currentSlicedIngredient = Instantiate(slicedIngredients[0], spawnPoint.transform.position, Quaternion.identity);
                    currentSlicedIngredient = Instantiate(slicedIngredients[0], spawnPoint.transform.position, Quaternion.identity);
                    Debug.Log("Tomate sliced");
                    tomateCount--;
                }
                else if (animalCount > 0) 
                {
                    currentSlicedIngredient = Instantiate(slicedIngredients[1], spawnPoint.transform.position, Quaternion.identity);
                    currentSlicedIngredient = Instantiate(slicedIngredients[1], spawnPoint.transform.position, Quaternion.identity);
                    currentSlicedIngredient = Instantiate(slicedIngredients[1], spawnPoint.transform.position, Quaternion.identity);
                    Debug.Log("Animal sliced");
                    animalCount--;
                }
                else if (berengenaCount > 0)
                {
                    currentSlicedIngredient = Instantiate(slicedIngredients[2], spawnPoint.transform.position, Quaternion.identity);
                    currentSlicedIngredient = Instantiate(slicedIngredients[2], spawnPoint.transform.position, Quaternion.identity);
                    currentSlicedIngredient = Instantiate(slicedIngredients[2], spawnPoint.transform.position, Quaternion.identity);
                    Debug.Log("Berengena sliced");
                    berengenaCount--;
                }
                else if (papaCount > 0)
                {
                    currentSlicedIngredient = Instantiate(slicedIngredients[3], spawnPoint.transform.position, Quaternion.identity);
                    currentSlicedIngredient = Instantiate(slicedIngredients[3], spawnPoint.transform.position, Quaternion.identity);
                    currentSlicedIngredient = Instantiate(slicedIngredients[3], spawnPoint.transform.position, Quaternion.identity);
                    Debug.Log("Papa sliced");
                    papaCount--;
                }
                else if (zapalloCount > 0)
                {
                    currentSlicedIngredient = Instantiate(slicedIngredients[4], spawnPoint.transform.position, Quaternion.identity);
                    currentSlicedIngredient = Instantiate(slicedIngredients[4], spawnPoint.transform.position, Quaternion.identity);
                    currentSlicedIngredient = Instantiate(slicedIngredients[4], spawnPoint.transform.position, Quaternion.identity);
                    Debug.Log("Zapallo sliced");
                    zapalloCount--;
                }
                else if (fideosCount > 0)
                {
                    currentSlicedIngredient = Instantiate(slicedIngredients[5], spawnPoint.transform.position, Quaternion.identity);
                    currentSlicedIngredient = Instantiate(slicedIngredients[5], spawnPoint.transform.position, Quaternion.identity);
                    currentSlicedIngredient = Instantiate(slicedIngredients[5], spawnPoint.transform.position, Quaternion.identity);
                }
                
        
                RemoveUsedIngredients();
            }
        }
    }
    
    void AddIngredient(GameObject ingredient)
    {
        if (ingredient.name == "Tomate(Clone)")
        {
            tomateCount++;
            addedIngredients.Add(ingredient);
        }
        else if (ingredient.name == "Animal(Clone)")
        {
            animalCount++;
            addedIngredients.Add(ingredient);
        }
        else if(ingredient.name == "Eggplant(Clone)")
        {
            berengenaCount++;
            addedIngredients.Add(ingredient);
        }
        else if (ingredient.name == "Potato(Clone)")
        {
            papaCount++;
            addedIngredients.Add(ingredient);
        }
        else if (ingredient.name == "Zucchini(Clone)")
        {
            zapalloCount++;
            addedIngredients.Add(ingredient);
        }
        else if (ingredient.name == "NoodlePackage(Clone)")
        {
            fideosCount++;
            addedIngredients.Add(ingredient);
        }
    }
    
    void RemoveUsedIngredients()
    {
        for (int i = addedIngredients.Count - 1; i >= 0; i--)
        {
            var item = addedIngredients[i];
            if ( item.name == "Tomate(Clone)" || item.name == "Animal(Clone)" || item.name == "Eggplant(Clone)" ||
                 item.name == "Potato(Clone)" || item.name == "Zucchini(Clone)" || item.name == "NoodlePackage(Clone)" )
            {
                addedIngredients.RemoveAt(i);
                Destroy(item);
            }
        }
    }
    
    // Todos los GameObjects instanciados tienen su nombre + (Clone)
    // Ejemplo: Apple Pie(Clone)
    // Para eliminar el objeto instanciado, se debe eliminar el objeto con el mismo nombre
    // Ejemplo: Apple Pie

    void RemoveIngredient(GameObject ingredient)
    {
        if (ingredient.name == "Tomate(Clone)")
        {
            tomateCount--;
            addedIngredients.Remove(ingredient);
        }
        else if (ingredient.name == "Animal(Clone)")
        {
            animalCount--;
            addedIngredients.Remove(ingredient);
        }
        else if (ingredient.name == "Eggplant(Clone)")
        {
            berengenaCount--;
            addedIngredients.Remove(ingredient);
        }
        else if (ingredient.name == "Potato(Clone)")
        {
            papaCount--;
            addedIngredients.Remove(ingredient);
        }
        else if (ingredient.name == "Zucchini(Clone)")
        {
            zapalloCount--;
            addedIngredients.Remove(ingredient);
        }
        else if (ingredient.name == "NoodlePackage(Clone)")
        {
            fideosCount--;
            addedIngredients.Remove(ingredient);
        }
        else if (ingredient.name == "TomateCortado(Clone)" || ingredient.name == "MEAT(Clone)" ||
                 ingredient.name == "EggplantCut(Clone)"|| ingredient.name == "PotatoCut" ||
                 ingredient.name == "ZucchiniCut(Clone)" || ingredient.name == "NoodlePackageCut(Clone)" )
        {
            addedIngredients.Remove(ingredient);
            currentSlicedIngredient = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Draggable"))
        {
            AddIngredient(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            canInteract = !canInteract;
        }
    }



    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Draggable"))
        {
            RemoveIngredient(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            canInteract = !canInteract;
        }
        

    }
}
