using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAEnemigo : MonoBehaviour
{
    //ARREGLAR
    float cooldownTrap1 = 5;
    float cooldownTrap2 = 3;
    float speed = 4;

    [SerializeField] private Transform objetivo;
    [SerializeField] private Transform objetivo2;

    private NavMeshAgent navMeshAgent;

    float counter;
    int result;
    public int type;
    NavMeshAgent agent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        counter = 0;
        result = Random.Range(0, 2); ;
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {


        //MOVIMIENTO
        //ELEGIR PLAYER 
        counter -= Time.deltaTime;
        if (counter <= 0)
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
        //DIRECCIÓN DEL PLAYER
        if (type == 1)
        {
            navMeshAgent.SetDestination(objetivo.position);
        }
        else if (type == 2)
        {
            navMeshAgent.SetDestination(objetivo2.position);
        }






    }
    public void HealthUp()
    {
        if (gameObject.GetComponent<Hearts>().health < gameObject.GetComponent<Hearts>().numOfHearts)
        {
            gameObject.GetComponent<Hearts>().health++;
        }
    }

    public void speedUp()
    {
        StartCoroutine(speedUpCo());
    }

    private IEnumerator speedUpCo()
    {

        agent.speed *= 1.25f;
        yield return new WaitForSeconds(5);
        agent.speed /= 1.25f;
    }
    public void reduceCooldown()
    {
        StartCoroutine(reduceCooldownCo());
    }

    private IEnumerator reduceCooldownCo()
    {
        cooldownTrap1 /= 2f;
        cooldownTrap2 /= 2f;
        yield return new WaitForSeconds(7.5f);
        cooldownTrap1 *= 2f;
        cooldownTrap2 *= 2f;

    }
    
}
