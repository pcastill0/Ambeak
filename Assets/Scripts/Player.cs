using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public string inputHorizontal;
    public string inputVertical;
    public string inputTrap;
    public float cooldownTrap1 = 5f;
    public float cooldownTrap2 = 5f;

    private Rigidbody2D rb;

    public GameObject trap;
    float counter = 0;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis(inputHorizontal);
        float vertical = Input.GetAxis(inputVertical);

        counter += Time.deltaTime;
        if (Input.GetButtonDown(inputTrap) && counter > cooldownTrap1)
        {
            GameObject trapp = Instantiate(trap, transform.position, transform.rotation);
            trapp.GetComponent<Trampa>().owner = gameObject;
            counter = 0;
        }

      transform.position += new Vector3(horizontal, vertical, 0) * Time.deltaTime * speed;

        if(horizontal != 0 || vertical != 0)
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
