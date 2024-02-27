
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour
{
    public GameObject owner;
    private Player player;
    float stunDuration = 1.0f;
    float stunTimer = 0f;
    bool isStunned;
    void Start()
    {
        isStunned = false;
    }

    void Update()
    {
        while (isStunned)
        {
            stunTimer += Time.deltaTime;
            if(stunTimer >= stunDuration)
            {
                EndStun();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && player == null)
        {
            player = collision.GetComponent<Player>();
            StartStun();
        }
    }
    void StartStun()
    {
        isStunned = true;
        player.isPlayerStunned = true;
        player.stunEffect.SetActive(true);
        
        Debug.Log("player stunned");
    }

    void EndStun()
    {
        isStunned = false;
        player.stunEffect.SetActive(false);
        player.isPlayerStunned = false;
        Debug.Log("player unstunned");
    }
   
}

