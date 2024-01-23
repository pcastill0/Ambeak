using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public string inputHorizontal;
    public string inputVertical;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis(inputHorizontal);
        float vertical = Input.GetAxis(inputVertical);
        transform.position += new Vector3(horizontal, vertical, 0) * Time.fixedDeltaTime * speed;

        //Vector2 movement = new Vector2(horizontal, vertical);
       // movement.Normalize(); // Ensure diagonal movement is not faster

       // rb.velocity = movement * speed;
    }

}
