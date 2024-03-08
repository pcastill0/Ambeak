using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public string inputHorizontal;
    public string inputVertical;
    public string inputTrap;
    public string inputTrap1;
    public string inputStun;
    public float cooldownTrap1 = 5f;
    public float cooldownTrap2 = 5f;
    public float cooldownTrap3 = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public GameObject trap1;
    public GameObject trap2;
    public GameObject trap3;
    public GameObject stun1;
    public GameObject stunEffect;
    public bool isPlayerStunned = false;
    public bool isDead;

    float counter = 0;
    float holeCDR = 3;
    float stunCDR = 5;
    float minaCDR = 0;

    Color playerCol;
    public float limiteXpos;
    public float limiteXneg;
    public float limiteYpos;
    public float limiteYneg;


    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCol = gameObject.GetComponent<SpriteRenderer>().color;
        isDead = false;
    }

    void FixedUpdate()
    {
        if (isDead)
        {
            gameObject.GetComponent<Player>().enabled = false;
        }
        //MOVIMIENTO PLAYER
        float horizontal = Input.GetAxis(inputHorizontal);
        float vertical = Input.GetAxis(inputVertical);
        if (!isPlayerStunned)
        {
            transform.position += new Vector3(horizontal, vertical, 0) * Time.deltaTime * speed;
        }

        //CONTADORES
        counter += Time.deltaTime;
        minaCDR += Time.deltaTime;
        //CONTADOR CDR
        if (gameObject.GetComponent<BoxCollider2D>().enabled == false)
        {
            holeCDR -= Time.deltaTime;
        }
        //TRAMPA OSO
/*
        if (Input.GetButtonDown(inputTrap) && counter > cooldownTrap1)
        {
            GameObject trap = Instantiate(trap1, transform.position, transform.rotation);
            trap.GetComponent<Trampa>().owner = gameObject;
            counter = 0;
        }*/

        //TRAMPA GUJERO
        if (Input.GetButtonDown(inputTrap1) && counter > 5)
        {
            holeCDR = 3;
            GameObject trap = Instantiate(trap2, transform.position, transform.rotation);
            trap.GetComponent<Trampa>().owner = gameObject;
            counter = 0;

            gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, .5f);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
     


        }
        //MINA
        if (Input.GetButtonDown(inputTrap) && minaCDR > cooldownTrap3)
        {
            GameObject mine = Instantiate(trap3, transform.position, transform.rotation);
            mine.GetComponent<Mina>().owner = gameObject;
            counter = 0;
        }

        //COMPROBACION TIEMPO (GUJERO)
        if (holeCDR <= 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().color = playerCol;
            holeCDR = 3;
            GameObject trap3 = Instantiate(trap2, transform.position, transform.rotation);
            trap3.GetComponent<Trampa>().owner = gameObject;
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

        //STUN
        stunCDR -= Time.deltaTime;

        Vector3 direction = new Vector3(Input.GetAxis(inputHorizontal), Input.GetAxis(inputVertical), 0);
        if (Input.GetButtonDown(inputStun) && stunCDR <= 0)
        {
            stunCDR = 5;
            if (direction.magnitude > 0.01f)
            {
                float angle = Mathf.Atan2(direction.x, -(direction.y)) * Mathf.Rad2Deg;
                GameObject stun = Instantiate(stun1, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
                stun.GetComponent<Stun>().owner = gameObject;
                Destroy(stun, 0.3f);
            }
            else
            {
                GameObject stun = Instantiate(stun1, transform.position, Quaternion.identity);
                stun.GetComponent<Stun>().owner = gameObject;
                Destroy(stun, 0.3f);
            }
        }
        //ANIMACIONES
        if (horizontal != 0 || vertical != 0)
        {
            animator.SetFloat("X", horizontal);
            animator.SetFloat("Y", vertical);

            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
     
   

    public void HealthUp()
    {
        if (gameObject.GetComponent<Hearts>().health < gameObject.GetComponent<Hearts>().numOfHearts) {
            gameObject.GetComponent<Hearts>().health++;
        }
    }

    public void speedUp()
    {
        StartCoroutine(speedUpCo());
    }

    private IEnumerator speedUpCo()
    {
        speed *= 1.25f;
        yield return new WaitForSeconds(5);
        speed /= 1.25f;
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
