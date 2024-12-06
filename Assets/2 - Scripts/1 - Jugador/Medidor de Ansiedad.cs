using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MedidordeAnsiedad : MonoBehaviour
{
    private GameManager gameManager;
    public Image MedidorAnsiedad;

    private GameObject panelRojo;
    private Image panelRojoImage;

    private float segundero = 0;
    public bool AnsiedadSuma = true;
    public GameObject panelNegro;
    public AudioSource audioSource;
    public AudioClip clip;
    
    void Start()
    {
        panelRojo = GameObject.Find("Panel Rojo");
        panelRojoImage = panelRojo.GetComponent<Image>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.puntosdeAnsiedad = 0;
    }


    void Update()
    {
        if (MedidorAnsiedad.fillAmount == 1 && !GameManager.instance.gameOver)
        {
            GameManager.instance.gameOver = true;
            GameManager.instance.finalesComprobation = true;
            panelNegro.SetActive(true);
            audioSource.clip = clip;
            audioSource.Play();
            SceneManager.LoadScene("Créditos");
            
        } 
        if (GameManager.instance.finalesComprobation == false)
        {
            if (gameManager.puntosdeAnsiedad != 1 && gameManager.pauseTimers == false)
            {
                if ( gameManager.puntosdeAnsiedad == 0 )
                {
                    AnsiedadSuma = true;
                }
                if (gameManager.puntosdeAnsiedad >= 1)
                {
                    gameManager.puntosdeAnsiedad = 1;
                    AnsiedadSuma = false;
                }
            
                if (AnsiedadSuma == false && gameManager.puntosdeAnsiedad < 1)
                {
                    AnsiedadSuma = true;    
                }

                if (AnsiedadSuma == true)
                { 
                    segundero += Time.deltaTime;
                    if (segundero >= 1)
                    {
                        gameManager.puntosdeAnsiedad += 0.005f * gameManager.MultiplicadordeAnsiedad;
                        segundero = 0;
                    }
                }
                CambiosPanelRojo();

            
            
            }
            if (MedidorAnsiedad.fillAmount != gameManager.puntosdeAnsiedad)
            {

                MedidorAnsiedad.fillAmount = (float) gameManager.puntosdeAnsiedad;
                //Debug.Log(MedidorAnsiedad.fillAmount);
            }
        }
        
    }


    public void CambiosPanelRojo()
    {
        Color colorActual = panelRojoImage.color;

        if (gameManager.puntosdeAnsiedad <= 0.4f && panelRojoImage.color.a != 0)
        {
            colorActual.a = 0f;
            panelRojoImage.color = colorActual;
        }
        if (gameManager.puntosdeAnsiedad >= 0.4f && gameManager.puntosdeAnsiedad <= 0.6f && panelRojoImage.color.a != 0.3f)
        {
            colorActual.a = 0.2f;
            panelRojoImage.color = colorActual;
        }

        if (gameManager.puntosdeAnsiedad >= 0.6f &&  gameManager.puntosdeAnsiedad <= 0.90f && panelRojoImage.color.a != 0.5f)
        {
            colorActual.a = 0.5f;
            panelRojoImage.color = colorActual;
        }
        
    }
}
