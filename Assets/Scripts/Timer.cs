using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public Player player1;
    public Player player2;
    public GameObject iaWin;
    public TMP_Text contadorText;
    public float tiempoInicial = 60f;
    private float tiempoRestante;
    public int contador;

    public GameObject[] jugadores;
    public GameObject[] textosVictoria;

    private void Start()
    {
        tiempoRestante = tiempoInicial;
        ActualizarContador();
        contador = 3;
    }

    private void Update()
    {
        if (tiempoRestante > 0f)
        {
            tiempoRestante -= Time.deltaTime;
            ActualizarContador();
        }
        else
        {
            tiempoRestante = 0f;
            ActualizarContador();

            if (player1 == null && player2 == null)
            {
                iaWin.SetActive(true);
                Time.timeScale = 0;
            }

            GameObject jugadorConMasVidas = null;
            int vidasMasAltas = 0;
            bool empate = false;

            foreach (GameObject jugador in jugadores)
            {
                Hearts hearts = jugador.GetComponent<Hearts>();
                if (hearts != null && hearts.health > vidasMasAltas)
                {
                    vidasMasAltas = hearts.health;
                    jugadorConMasVidas = jugador;
                    empate = false;
                }
                else if (hearts != null && hearts.health == vidasMasAltas)
                {
                    empate = true;
                }
            }

            if (empate)
            {
                Debug.Log("Empate");
                ReiniciarTemporizador();
            }
            else if (jugadorConMasVidas != null)
            {
                Debug.Log("PlayerWinner: " + jugadorConMasVidas.name);
                
                for (int i = 0; i < jugadores.Length; i++)
                {
                   
                    if (jugadores[i] == jugadorConMasVidas)
                    {
                        textosVictoria[i].SetActive(true);
                        Time.timeScale = 0;
                      
                    }
                    else
                    {
                        textosVictoria[i].SetActive(false);
                    }
                }
            }
            else
            {
                Debug.Log("Error");
            }
        }
    }

    private void ActualizarContador()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60f);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60f);
        contadorText.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    private void ReiniciarTemporizador()
    {
      
        tiempoRestante = tiempoInicial;
        ActualizarContador();

      
        foreach (var textoVictoria in textosVictoria)
        {
            textoVictoria.SetActive(false);
        }
    }
}