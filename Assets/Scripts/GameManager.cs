using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float counter = 0;
    public GameObject powerUp1;
    public GameObject powerUp2;
    public GameObject powerUp3;

    public AudioClip sonidoMina;
    private AudioSource audioSource;

    public GameObject pausaMenuUI;
    public GameObject Menu;
    public GameObject vol;
    public GameObject options;
    public GameObject returnButton;
    public GameObject info_cosas;
    public GameObject boton_info;

   


   

    // Start is called before the first frame update
    void Start()
    {
        info_cosas.SetActive(false);
        pausaMenuUI.SetActive(false);
        vol.SetActive(false);
        options.SetActive(false);

    }
    
    public void ver_info()
    {
        vol.SetActive(false);
        info_cosas.SetActive(true);
    }
    public void returnToOptions()
    {
        options.SetActive(true);
        vol.SetActive(false);
        info_cosas.SetActive(false);

    }
    public void globalSettings()
    {
        options.SetActive(false);
        vol.SetActive(true);
       

    }
    public void reanudarJuego()
    {
        Time.timeScale = 1f;
        pausaMenuUI.SetActive(false);
    }
    public void reiniciarJuego()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void reproducirAudio()
    {
        audioSource = GetComponent<AudioSource>();


        audioSource.clip = sonidoMina; 
        
        audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        //PAUSAR JUEGO
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f; // Reanudar el juego
                pausaMenuUI.SetActive(false);
                options.SetActive(false);
                vol.SetActive(false);
            }
            else
            {
                Time.timeScale = 0f; // Pausar el juego
                pausaMenuUI.SetActive(true);
                options.SetActive(true);
                vol.SetActive(false);
            }
        }
        counter += Time.deltaTime;
        if (counter > 4)
        {
            GameObject power;
            int rand = Random.Range(0, 3);
            counter = 0;
            switch (rand)
            {
                case 0:
                    power = Instantiate(powerUp1, transform.position, transform.rotation);
                    power.transform.position = new Vector2(Random.Range(-9, 9), Random.Range(-4, 4));
                    break;
                case 1:
                    power = Instantiate(powerUp2, transform.position, transform.rotation);
                    power.transform.position = new Vector2(Random.Range(-9, 9), Random.Range(-4, 4));
                    break;
                case 2:
                    power = Instantiate(powerUp3, transform.position, transform.rotation);
                    power.transform.position = new Vector2(Random.Range(-9, 9), Random.Range(-4, 4));
                    break;
            }


        }
    }
}

