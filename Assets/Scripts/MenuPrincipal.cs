using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject ControlesMenu;
    public GameObject OpcionesMenu;
    public GameObject MenuP;

    void Start()
    {
        ControlesMenu.SetActive(false);
        OpcionesMenu.SetActive(false);
        MenuP.SetActive(true);
    }


    public void EmpezarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(1); 
    }

    public void Menu ()
    {
        SceneManager.LoadScene(0);
    }

    public void Controles()
    {
        MenuP.SetActive(false);
        ControlesMenu.SetActive(true);
    }
    public void Opciones()
    {
        MenuP.SetActive(false);
        OpcionesMenu.SetActive(true);
    }

    public void Volver()
    {
        MenuP.SetActive(true);
        ControlesMenu.SetActive(false);
    }

    
}
