using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject a;
    public GameObject b;
    public int type;
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
            if (type == 1)
            {
                Destroy(a, 0f);
            }
            if(type == 2)
            {
                Destroy(b, 0f);
            }
        }
    }
}
