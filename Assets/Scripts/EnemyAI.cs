using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float speed = 3f;

    void Update()
    {
        if (player1 != null && player2 != null)
        {
            // Obtiene la dirección y distancia hacia Player1
            Vector3 directionToPlayer1 = player1.position - transform.position;
            float distanceToPlayer1 = directionToPlayer1.magnitude;

            // Obtiene la dirección y distancia hacia Player2
            Vector3 directionToPlayer2 = player2.position - transform.position;
            float distanceToPlayer2 = directionToPlayer2.magnitude;

            // Selecciona al jugador más cercano
            Transform targetPlayer = (distanceToPlayer1 < distanceToPlayer2) ? player1 : player2;

            // Obtiene la dirección hacia el jugador más cercano
            Vector3 directionToTargetPlayer = targetPlayer.position - transform.position;

            // Normaliza la dirección para mantener una velocidad constante
            directionToTargetPlayer.Normalize();

            // Mira hacia la dirección del jugador más cercano
            transform.up = directionToTargetPlayer;

            // Mueve al enemigo hacia el jugador más cercano
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }
}