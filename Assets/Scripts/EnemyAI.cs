using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Player jugador1;
    public Player jugador2;
    public float speed = 3f;
    public float contador;
    public float holeCDR = 1f;
    public GameObject trap1;
    public GameObject trap2;
    public GameObject trap3;
    public int number;
    public bool hole;
    Color playerCol;

    public float limiteXpos;
    public float limiteXneg;
    public float limiteYpos;
    public float limiteYneg;



   

    void Start()
    {
        contador = 0;
        playerCol = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
       
        
            if (gameObject.GetComponent<BoxCollider2D>().enabled == false)
            {
                holeCDR -= Time.deltaTime;
                hole = true;
            }
            if (gameObject.GetComponent<BoxCollider2D>().enabled == true)
            {
                contador += Time.deltaTime;
            }
            else
            {
                contador = 0;
            }

            if (player1 != null || player2 != null)
            {
                Transform targetPlayer = null;

                if (player1 != null && player2 != null)
                {
                    Vector3 directionToPlayer1 = player1.position - transform.position;
                    float distanceToPlayer1 = directionToPlayer1.magnitude;
                    Vector3 directionToPlayer2 = player2.position - transform.position;
                    float distanceToPlayer2 = directionToPlayer2.magnitude;

                    targetPlayer = (distanceToPlayer1 < distanceToPlayer2) ? player1 : player2;
                }
                else if (player1 != null)
                {
                    targetPlayer = player1;
                }
                else if (player2 != null)
                {
                    targetPlayer = player2;
                }

                if (targetPlayer != null)
                {
                    Vector3 directionToTargetPlayer = targetPlayer.position - transform.position;
                    directionToTargetPlayer.Normalize();

                    transform.position += directionToTargetPlayer * speed * Time.deltaTime;
                }
            }

            if (contador >= 5f)
            {
                number = 2;
                if (!hole)
                {
                    if (number == 0)
                    {
                        GameObject trap = Instantiate(trap1, transform.position, Quaternion.identity);
                        trap.GetComponent<Trampa>().owner = gameObject;
                        contador = 0;
                    }
                    else if (number == 1)
                    {
                        GameObject trap = Instantiate(trap2, transform.position, Quaternion.identity);
                        trap.GetComponent<Trampa>().owner = gameObject;
                        contador = 0;
                        gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, .5f);
                        gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    }
                else if (number == 2)
                {
                    GameObject trap = Instantiate(trap3, transform.position, Quaternion.identity);
                    trap.GetComponent<Trampa>().owner = gameObject;
                    contador = 0;
                }
            }
            }

            //COMPROBACION TIEMPO (GUJERO)
            if (holeCDR <= 0)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                gameObject.GetComponent<SpriteRenderer>().color = playerCol;
                holeCDR = 3;
                GameObject trap3 = Instantiate(trap2, transform.position, Quaternion.identity);
                trap3.GetComponent<Trampa>().owner = gameObject;
                hole = false;
                Destroy(trap3, 2);
            }

            //LIMITES MOVIMIENTO
            if (transform.position.x < limiteXneg)
            {
                transform.position = new Vector3(limiteXneg, transform.position.y, 0);
            }
            if (transform.position.x > limiteXpos)
            {
                transform.position = new Vector3(limiteXpos, transform.position.y, 0);
            }
            if (transform.position.y < limiteYneg)
            {
                transform.position = new Vector3(transform.position.x, limiteYneg, 0);
            }
            if (transform.position.y > limiteYpos)
            {
                transform.position = new Vector3(transform.position.x, limiteYpos, 0);
            }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            
            
                collision.GetComponent<IAHearts>().health -= 1;

                Destroy(this.gameObject);
            
        }
    }


}