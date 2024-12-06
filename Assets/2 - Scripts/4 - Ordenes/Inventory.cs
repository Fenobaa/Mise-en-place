using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<GameObject> panelesPedidos;
    public PlatosScriptable[] platos = new PlatosScriptable[3];
    private PlatosScriptable[] pedidos = new PlatosScriptable[3];
    public GameObject platoPanelPB;
    public RectTransform pedidosPanel;

    public int maxOrders;
    public int ordersSpawnTime;
    private int createdOrders;
    private bool createOrders = false;
    private bool alreadyCreating = false;

    private bool jobEnded;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;  // Asigna la instancia a la de este GameManager
            DontDestroyOnLoad(this); // Hace que el GameManager persista entre escenas
        }
        else
        {
            Destroy(this);  // Si ya existe una instancia, destruye este GameManager
        }
    }
    private void Update()
    {

        if (!createOrders && !GameManager.instance.pauseTimers)
        {
            createOrders = true;
        }
    
        if (createOrders && !alreadyCreating)
        {
            Debug.Log("Iniciando creación de pedidos...");
            alreadyCreating = true;
            StartCoroutine(NewOrder());
        }

        if (createdOrders == 8)
        {
            jobEnded = true;
        }
    }

    IEnumerator NewOrder()
    {
        createOrders = true;
        if (jobEnded == false)
        {
            while (GameManager.instance.ordersCreated < maxOrders && createdOrders != 8 && createdOrders <= 8)
            {
                if (GameManager.instance.pauseTimers)
                {
                    createOrders = false;
                    alreadyCreating = false;
                    yield break; // Salir de la corrutina si el temporizador está en pausa
                }
        
                // Generar un nuevo pedido
                int randomIndex = Random.Range(0, platos.Length);
                PlatosScriptable platoSeleccionado = platos[randomIndex];
        
                GameObject newPedido = Instantiate(platoPanelPB, pedidosPanel);
                newPedido.GetComponent<PrefabUpdater>().thisPlatoScriptable = platoSeleccionado;
                newPedido.transform.localScale = Vector3.one;
                newPedido.transform.localPosition = Vector3.zero;
                newPedido.transform.localRotation = Quaternion.identity;
                createdOrders++;

                AddPedido(newPedido);
                GameManager.instance.ordersCreated++;
                if (jobEnded)
                {
                    yield break;
                }
                yield return new WaitForSeconds(ordersSpawnTime);

            }
        }
        

        // Finalizar creación
        alreadyCreating = false;
        createOrders = false;


    }

    IEnumerator StartNewOrderWithDelay()
    {
        yield return new WaitForSeconds(ordersSpawnTime);
        StartCoroutine(NewOrder());
    }
    public void AddPedido(GameObject panelPedido)
    {
        panelesPedidos.Add(panelPedido);
    }

    public void RemovePedido(GameObject panelPedido)
    {
        panelesPedidos.Remove(panelPedido);
        GameManager.instance.ordersCreated--;
        if (GameManager.instance.ordersCreated < maxOrders)
        {
            createOrders = true;

            // Si no hay una corrutina activa, reiníciala
            if (!alreadyCreating)
            {
                alreadyCreating = true;
                StartCoroutine(StartNewOrderWithDelay());
            }
        }
    }
    
    
    
}