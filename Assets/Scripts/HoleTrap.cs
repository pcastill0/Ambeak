using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrap : MonoBehaviour
{
    public GameManager manager;
    public GameObject owner;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
                manager.reproducirEmpuje();
                collision.GetComponent<Hearts>().modifyHealth(-1);
                Destroy(gameObject);

            }
        }
    }

}
