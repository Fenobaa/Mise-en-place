using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OPTIONS : MonoBehaviour
{
    public GameObject PanelBotones;
    public GameObject PanelSonido;

    public void OptionsButton()
    {
        PanelSonido.SetActive(true);
        PanelBotones.SetActive(false);
    }

    public void OptionsBackButton()
    {
        PanelSonido.SetActive(false);
        PanelBotones.SetActive(true);
        
    }

    public void CreditosButton()
    {
        SceneManager.LoadScene("Créditos");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Main menu y sonido");
    }

    //public void PlayButton()
    //{
    //Aca poni la escena de juego //SceneManager.LoadScene("NOMBRE ESCENA");//
    //}

    public void ExitButton()
    {
        Application.Quit();
    }

    private void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
