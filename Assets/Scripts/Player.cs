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

    public int playerIndex = 0;

    private Vector2 movementInput = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    void Update()
    {
        //float horizontal = Input.GetAxis(inputHorizontal);
        //float vertical = Input.GetAxis(inputVertical);

        counter += Time.deltaTime;


        //transform.position += new Vector3(horizontal, vertical, 0) * Time.deltaTime * speed;

        transform.position += new Vector3(movementInput.x, movementInput.y, 0) * Time.deltaTime * speed;

        if (movementInput.x != 0 || movementInput.y != 0)
        {
            animator.SetFloat("X", movementInput.x);
            animator.SetFloat("Y", movementInput.y);

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
    public void trap1Pressed(bool pressed)
    {
        Debug.Log("hola");
        if (pressed && counter > cooldownTrap1)
        {
            GameObject trapp = Instantiate(trap, transform.position, transform.rotation);
            trapp.GetComponent<Trampa>().owner = gameObject;
            counter = 0;
        }
    }

    public void SetInputVector(Vector2 direction)
    {
        movementInput = direction;
    }
}
