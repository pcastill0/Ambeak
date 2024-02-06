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

    private Rigidbody2D rb;

    public GameObject trap1;
    public GameObject trap2;
    float counter = 0;
    float holeCDR = 3;
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
    }
    
    void FixedUpdate()
    {
        //MOVIMIENTO PLAYER
        float horizontal = Input.GetAxis(inputHorizontal);
        float vertical = Input.GetAxis(inputVertical);
        transform.position += new Vector3(horizontal, vertical, 0) * Time.deltaTime * speed;
        
        //CONTADORES
        counter += Time.deltaTime;
        //CONTADOR CDR
        if(gameObject.GetComponent<BoxCollider2D>().enabled == false){
            holeCDR -= Time.deltaTime;
        }
        //TRAMPA OSO
        if (Input.GetButtonDown(inputTrap) && counter > 5)
        {
            GameObject trap = Instantiate(trap1, transform.position, transform.rotation);
            trap.GetComponent<Trampa>().owner = gameObject;
            counter = 0;
        }
        
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
        //COMPROBACION TIEMPO (GUJERO)
        if(holeCDR <= 0){
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                gameObject.GetComponent<SpriteRenderer>().color = playerCol;
                holeCDR = 3;
               GameObject trap3 = Instantiate(trap2, transform.position, transform.rotation);
               trap3.GetComponent<Trampa>().owner = gameObject;
               Destroy(trap3, 2);
               }

       //LIMITES MOVIMIENTO
        if(transform.position.x < limiteXneg)
        {
            transform.position = new Vector3(limiteXneg, transform.position.y, 0);
        }
        if(transform.position.x > limiteXpos)
        {
            transform.position = new Vector3(limiteXpos, transform.position.y, 0);
        }
        if(transform.position.y < limiteYneg)
        {
            transform.position = new Vector3(transform.position.x, limiteYneg, 0);
        }
        if(transform.position.y > limiteYpos)
        {
           transform.position = new Vector3(transform.position.x, limiteYpos, 0);
        }


        //ANIMACIONES
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
