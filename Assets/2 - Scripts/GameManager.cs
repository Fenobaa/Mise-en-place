using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Instancia estática para acceder desde otros scripts
    public static GameManager instance;
    public bool canDrag;
    public bool itemPicked;
    

    public double puntosdeAnsiedad; //nivel de ansiedad
    public float MultiplicadordeAnsiedad = 1;

    public TextMeshProUGUI textIndicaciones;
    public TextMeshProUGUI textAdvertencias;
    public bool pauseTimers;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;  // Asigna la instancia a la de este GameManager
            DontDestroyOnLoad(gameObject); // Hace que el GameManager persista entre escenas
        }
        else
        {
            Destroy(gameObject);  // Si ya existe una instancia, destruye este GameManager
        }
    }
    
    
}

