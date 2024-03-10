
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour
{
    public GameObject owner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        IAEnemigo iAEnemigo = collision.GetComponent<IAEnemigo>();

        if (player != null)
        {
            if (collision.gameObject.CompareTag("Player") && collision.gameObject != owner)
            {
                player.isPlayerStunned = true;
                player.stunEffect.SetActive(true);
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Player") && collision.gameObject != owner)
            {
                iAEnemigo.isPlayerStunned = true;
                iAEnemigo.stunEffect.SetActive(true);
            }
        }
    }
   
}

