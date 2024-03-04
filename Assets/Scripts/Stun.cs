
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour
{
    public GameObject owner;
    private Player player;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject != owner)
        {
            player = collision.GetComponent<Player>();
            player.isPlayerStunned = true;
            //player.stunEffect.SetActive(true);
        }
    }
   
}

