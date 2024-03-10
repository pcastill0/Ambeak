using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClonBomba : MonoBehaviour
{
    public GameObject owner;
    float speed = 4;
   
    [SerializeField] private Transform objetivo;
    [SerializeField] private Transform objetivo2;
    [SerializeField] private Transform objetivo3;

    private NavMeshAgent navMeshAgent;

    Color playerCol;

    public GameObject player1A;
    public GameObject player2a;
    public GameObject IA;

    int randomTarget;
    float counter;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;

    public Transform player1T;
    public Transform player2T;
    public Transform player3T;

    NavMeshAgent agent;
    int num;
    

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        counter = 0;
       
        playerCol = gameObject.GetComponent<SpriteRenderer>().color;

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("iaprueba");

        player1T = player1.transform;
        player2T = player2.transform;
        player3T = player3.transform;
  
    }

    private void Update()
    {
        counter -= Time.deltaTime;

        if (counter <= 0)
        {
            randomTarget = Random.Range(0, 3);
            counter = 5;
        }
  
        if (owner == player1)
        {
            Debug.Log("Entro");
            switch (randomTarget)
            {
                //SI LO TIRA EL PLAYER1 QUE SIGA AL 2 O A LA IA
                case 1:
                    if (player3T != null && player3T.gameObject.activeSelf)
                    {
                        navMeshAgent.SetDestination(player3T.position);
                    }
                    else
                    {
                        if (player2T != null && player2T.gameObject.activeSelf)
                        {
                            navMeshAgent.SetDestination(player2T.position);
                        }
                    }
                    break;
                case 2:
                    if (player2T != null && player2.gameObject.activeSelf)
                    {
                        navMeshAgent.SetDestination(player2T.position);
                    }
                    else
                    {
                        if (player3T != null && player3.gameObject.activeSelf)
                        {
                            navMeshAgent.SetDestination(player3T.position);
                        }

                    }
                    break;
                default:
                    navMeshAgent.ResetPath();
                    break;
            }
        }
        else if (owner == player2)
        {
            switch (randomTarget)
            {
                //SI LO TIRA EL PLAYER 2, QUE SIGA A LA IA o al PLAYER1
                case 1:
                    if (player1T != null && player1.gameObject.activeSelf)
                    {
                        navMeshAgent.SetDestination(player1T.position);
                    }
                    else
                    {
                        if (player3T != null && player3.gameObject.activeSelf)
                        {
                            navMeshAgent.SetDestination(player3T.position);
                        }
                    }
                    break;
                case 2:
                    if (player3T != null && player3.gameObject.activeSelf)
                    {
                        navMeshAgent.SetDestination(player3T.position);
                    }
                    else
                    {
                        if (player1T != null && player1.gameObject.activeSelf)
                        {
                            navMeshAgent.SetDestination(player1T.position);
                        }

                    }
                    break;
                default:
                    navMeshAgent.ResetPath();
                    break;
            }
        }
         




    }
   

}

