using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Menu : MonoBehaviour
{
    /*
    public GameObject setings;
    public GameObject returnMenu;
    public GameObject boton_info;
    public GameObject escena_info;
    */
    

    public GameObject menu;
    /*
     void Start()
    {
        returnMenu.SetActive(false);
        setings.SetActive(false);
        menu.SetActive(true);
        escena_info.SetActive(false);
        boton_info.SetActive(false);
    }

    public void mostrar_info()
    {
        boton_info.SetActive(false);
        setings.SetActive(false);
        escena_info.SetActive(true);
    }
    public void returnMen()
    {
        returnMenu.SetActive(false);
        setings.SetActive(false);
        menu.SetActive(true);
        boton_info.SetActive(false);
        escena_info.SetActive(false);
    }
    public void LoadSettings()
    {
        returnMenu.SetActive(true);
        boton_info.SetActive(true);
        setings.SetActive(true);
        menu.SetActive(false);
    }
    */
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Debug.Log("He salido de la aplicacion");
        Application.Quit();
    }

    public void ReturnToPrevious()
    {
        int previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;

        if (previousSceneIndex >= 0)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
        else
        {
            Debug.LogWarning("No hay anterior");
        }
    }
}