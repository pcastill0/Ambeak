using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public string inputHorizontal;
    public string inputVertical;
    public Animator animator;

    void Start()
    {
         
    }
    void Update()
    {
        float horizontal = Input.GetAxis(inputHorizontal);
        float vertical = Input.GetAxis(inputVertical);

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
