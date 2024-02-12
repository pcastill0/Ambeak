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
            // Obtiene la direcci�n y distancia hacia Player1
            Vector3 directionToPlayer1 = player1.position - transform.position;
            float distanceToPlayer1 = directionToPlayer1.magnitude;

            // Obtiene la direcci�n y distancia hacia Player2
            Vector3 directionToPlayer2 = player2.position - transform.position;
            float distanceToPlayer2 = directionToPlayer2.magnitude;

            // Selecciona al jugador m�s cercano
            Transform targetPlayer = (distanceToPlayer1 < distanceToPlayer2) ? player1 : player2;

            // Obtiene la direcci�n hacia el jugador m�s cercano
            Vector3 directionToTargetPlayer = targetPlayer.position - transform.position;

            // Normaliza la direcci�n para mantener una velocidad constante
            directionToTargetPlayer.Normalize();

            // Mira hacia la direcci�n del jugador m�s cercano
            transform.up = directionToTargetPlayer;

            // Mueve al enemigo hacia el jugador m�s cercano
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }
}