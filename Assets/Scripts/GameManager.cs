using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
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

    private cuenta_atras cuentaAtrasScript;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        Invoke("ReanudarJuego", 8f);
        pausaMenuUI.SetActive(false);
       
    }
    void ReanudarJuego()
    {
        // Reanudar el juego
        Time.timeScale = 1f;
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
        // PAUSAR JUEGO
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f; // Reanudar el juego
                pausaMenuUI.SetActive(false);
            }
            else
            {
                if (cuentaAtrasScript.gameObject.activeSelf)
                {
                    // Si la cuenta atrás está activa, pausar el juego
                    Time.timeScale = 0f;
                }
                else
                {
                    Time.timeScale = 1f; // Si no, pausar el juego normalmente
                    pausaMenuUI.SetActive(true);
                }
            }
        }

        // Generate powerUps
        counter += Time.deltaTime;
        if (counter > 4)
        {
            GameObject power;
            int rand = Random.Range(0, 3);
            counter = 0;
            float x;
            float y;
            NavMeshHit hit;
            x = Random.Range(-9, 9);
            y = Random.Range(-4, 4);
            NavMesh.SamplePosition(new Vector2(x, y), out hit, Mathf.Infinity, NavMesh.AllAreas);

            switch (rand)
            {
                
                case 0:
                    power = Instantiate(powerUp1, transform.position, transform.rotation);
                    power.transform.position = hit.position;
                    break;
                case 1:
                    power = Instantiate(powerUp2, transform.position, transform.rotation);
                    power.transform.position = hit.position;
                    break;
                case 2:
                    power = Instantiate(powerUp3, transform.position, transform.rotation);
                    power.transform.position = hit.position;
                    break;
            }
        }
    }
}
