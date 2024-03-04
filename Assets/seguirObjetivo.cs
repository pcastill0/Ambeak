using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAEnemigo : MonoBehaviour
{

    [SerializeField] private Transform objetivo;
    [SerializeField] private Transform objetivo2;

    private NavMeshAgent navMeshAgent;

    float counter;
    int result;
    int type;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        counter = 0;
        result = Random.Range(0, 2); ;
        
    }

    private void Update()
    {
        counter -= Time.deltaTime;
        if(counter <= 0)
        {
            result = Random.Range(0, 2);
            if (result == 0)
            {
                type = 1;
            }
            else if (result == 1)
            {
                type = 2;
            }
            counter = 5;
        }


        
        if (type == 1)
        {
            navMeshAgent.SetDestination(objetivo.position);
        }
        else if (type == 2)
        {
            navMeshAgent.SetDestination(objetivo2.position);
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
