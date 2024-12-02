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
    public PlatosScriptable[] platos = new PlatosScriptable[5];
    private PlatosScriptable[] pedidos = new PlatosScriptable[5];
    public GameObject platoPanelPB;
    public RectTransform pedidosPanel;

    public int maxOrders;
    private int ordersCreated = 0;
    public int ordersSpawnTime;
    
    private bool createOrders = false;
    private bool alreadyCreating = false;



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

        if (createOrders == false && GameManager.instance.pauseTimers == false )
        {
            createOrders = true;
            
        }

        if (createOrders == true && GameManager.instance.pauseTimers == false 
                                 && ordersCreated < maxOrders && alreadyCreating == false)
        {
            alreadyCreating = true;
            StartCoroutine(NewOrder());
        }
    }

    IEnumerator NewOrder()
    {
        createOrders = true;
        
        for (int i = 0; i < pedidos.Length; i++)
        {
            if (GameManager.instance.pauseTimers == false)
            {
                if (ordersCreated < maxOrders)
                {
                    int randomIndex = Random.Range(0, pedidos.Length);
                    PlatosScriptable platoSeleccionado = platos[randomIndex];
                    
                    pedidos[i] = platoSeleccionado;
                    GameObject newPedido = Instantiate(platoPanelPB, pedidosPanel);
            
                    newPedido.GetComponent<PrefabUpdater>().thisPlatoScriptable = platoSeleccionado;
                    newPedido.transform.localScale = Vector3.one; // Mantén la escala original
                    newPedido.transform.localPosition = Vector3.zero; // Opcional: centra al hijo en el padre
                    newPedido.transform.localRotation = Quaternion.identity; // Opcional: reinicia rotación
            
                    AddPedido(newPedido);
                    ordersCreated++;

                }
                else
                {
                    break;
                }
                
            }

            if (GameManager.instance.pauseTimers == true)
            {
                createOrders = false;
                alreadyCreating = false;
                break;
            }
            yield return new WaitForSeconds(ordersSpawnTime);
            
        }

    }

    public void AddPedido(GameObject panelPedido)
    {
        panelesPedidos.Add(panelPedido);
    }

    public void RemovePedido(GameObject panelPedido)
    {
        panelesPedidos.Remove(panelPedido);
    }
    
    
    
}