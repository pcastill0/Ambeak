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

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        pausaMenuUI.SetActive(false);   
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
    

    void Update()
    {
        //PAUSAR JUEGO
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f; // Reanudar el juego
                pausaMenuUI.SetActive(false);
            }
            else
            {
                Time.timeScale = 0f; // Pausar el juego
                pausaMenuUI.SetActive(true);
            }
        }

        //Generate powerUps
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

