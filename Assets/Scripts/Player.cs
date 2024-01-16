using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public string inputHorizontal;
    public string inputVertical;

    void Start()
    {

    }
    void Update()
    {
        float horizontal = Input.GetAxis(inputHorizontal);
        float vertical = Input.GetAxis(inputVertical);
        transform.position += new Vector3(horizontal, vertical, 0) * Time.deltaTime * speed;
    }
}
