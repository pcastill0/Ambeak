using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAEnemigo : MonoBehaviour
{
    float cooldownTrap1 = 5;
    float cooldownTrap2 = 3;
    float cooldownTrap3 = 4;
    float speed = 4;

    [SerializeField] private Transform objetivo;
    [SerializeField] private Transform objetivo2;

    private NavMeshAgent navMeshAgent;

    public GameObject trap1;
    public GameObject trap2;
    public GameObject trap3;
    Color playerCol;
    public GameObject empujeTrap;

    float holeCDR = 3;
    float counter;
    int result;
    public int type;
    NavMeshAgent agent;
    int num;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        counter = 0;
        result = Random.Range(0, 2); ;
        agent = GetComponent<NavMeshAgent>();
        playerCol = gameObject.GetComponent<SpriteRenderer>().color;
        holeCDR = 3;

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



        
        cooldownTrap1 -= Time.deltaTime;
        cooldownTrap2 -= Time.deltaTime;
        cooldownTrap3 -= Time.deltaTime;

         num = Random.Range(0, 3);

        if (num == 0 && cooldownTrap1 <= 0)
        {
            //TRAMPA MINA
            GameObject mina = Instantiate(trap1, transform.position, transform.rotation);
            mina.GetComponent<Trampa>().owner = gameObject;
            cooldownTrap1 = 5;
        }
        if(num == 1 && cooldownTrap2 <= 0)
        {
            //TRAMPA EMPUJE
            GameObject empuje = Instantiate(empujeTrap, transform.position, transform.rotation);
            empuje.GetComponent<Mina>().owner = gameObject;
            cooldownTrap2 = 5;
        }

            //CDR EMPUJE
        if (gameObject.GetComponent<BoxCollider2D>().enabled == false)
        {
            holeCDR -= Time.deltaTime;
        }

        if (num == 2 && cooldownTrap3 <= 0)
        {
            //TRAMPA EMPUJE
            GameObject trap = Instantiate(trap2, transform.position, transform.rotation);
            trap.GetComponent<HoleTrap>().owner = gameObject;
            cooldownTrap3 = 5;


            gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, .5f);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (holeCDR <= 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().color = playerCol;
            holeCDR = 3;
            GameObject trap3 = Instantiate(trap2, transform.position, transform.rotation);
            trap3.GetComponent<HoleTrap>().owner = gameObject;
            Destroy(trap3, 2);
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
