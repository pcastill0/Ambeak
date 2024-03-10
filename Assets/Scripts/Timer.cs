using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text contadorText;

    public float tiempoInicial = 60f;
    private float tiempoRestante;
    public int contador;

    public GameObject[] jugadores;
    public GameObject[] textosVictoria;
    public GameObject menuFinal;

    public int vidasMasAltas;
    public bool empate;
    public GameObject jugadorConMasVidas;
    public int playersLeft;
    private void Start()
    {
        tiempoRestante = tiempoInicial;
        ActualizarContador();
        contador = 3;
    }

    private void Update()
    {
        tiempoRestante -= Time.deltaTime;
        if(tiempoRestante < 0 )
        {
            tiempoRestante = 0;
        }
        ActualizarContador();

        jugadorConMasVidas = null;
        vidasMasAltas = 0;
        empate = false;
        playersLeft = 0;

        foreach (GameObject jugador in jugadores)
        {
            
            if (jugador != null)
            {
                playersLeft++;
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
        }

        if (empate && tiempoRestante == 0)
        {
            ReiniciarTemporizador();
        } 
        else if ( playersLeft == 1 || tiempoRestante == 0)
        {
            for (int i = 0; i < jugadores.Length; i++)
            {
                if (jugadores[i] == jugadorConMasVidas)
                {
                    textosVictoria[i].SetActive(true);
                    menuFinal.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    textosVictoria[i].SetActive(false);
                }
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