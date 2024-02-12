using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    public int health;
    public int numOfHearts;
    public int tipo;
    public Player player;
    public EnemyAI enemy;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

void Update()
    {
        if (health <= 0 && tipo == 0)
        {
            player.transform.position = new Vector3(1000, 1000, 0);
            player.enabled = false;
            player.GetComponent<SpriteRenderer>().enabled = false;
            player.GetComponent<BoxCollider2D>().enabled = false;

        }
        else if(health <= 0 && tipo == 1)
        {
            enemy.transform.position = new Vector3(1000, 1000, 0);
            enemy.enabled = false;
            enemy.GetComponent<SpriteRenderer>().enabled = false;
            enemy.GetComponent<BoxCollider2D>().enabled = false;
        }
     
        if (health > numOfHearts){
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHearts){
                hearts[i].enabled = true;
            }
            else{
                hearts[i].enabled = false;
            }

        }
    }


}
