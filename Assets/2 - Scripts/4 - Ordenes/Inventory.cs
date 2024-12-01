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
    public PlatosScriptable[] platos = new PlatosScriptable[4];
    private PlatosScriptable[] pedidos = new PlatosScriptable[4];
    public GameObject platoPanelPB;
    public RectTransform pedidosPanel;

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

    private void Start()
    {
        StartCoroutine(NewOrder());
    }

    IEnumerator NewOrder()
    {
        for (int i = 0; i < pedidos.Length; i++)
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
            yield return new WaitForSeconds(6);
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