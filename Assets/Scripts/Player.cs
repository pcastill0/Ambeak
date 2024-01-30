using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public string inputHorizontal;
    public string inputVertical;
    public string inputTrap;

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
        if (Input.GetButtonDown(inputTrap) && counter > 5)
        {
            GameObject trapp = Instantiate(trap, transform.position, transform.rotation);
            trapp.GetComponent<Trampa>().owner = gameObject;
            counter = 0;
        }

        //Vector2 movement = new Vector2(horizontal, vertical);
        // movement.Normalize(); // Ensure diagonal movement is not faster

        // rb.velocity = movement * speed;
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

}
