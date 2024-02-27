using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrap : MonoBehaviour
{
    public Animator animator;
    public GameObject owner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject != owner)
            {
                collision.GetComponent<Hearts>().health -= 1;
                Destroy(this.gameObject);

            }
        }
    }

}
