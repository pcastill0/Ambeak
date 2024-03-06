using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PowerUps : MonoBehaviour
{
    // Start is called before the first frame update
    public int type;
  
  
    void Awake()
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
            if (collision.GetComponent<Player>() != null)
            {
                switch (type)
                {
                    case 1:
                        collision.GetComponent<Player>().HealthUp();
                        break;

                    case 2:
                        collision.GetComponent<Player>().speedUp();
                        break;

                    case 3:
                        collision.GetComponent<Player>().reduceCooldown();
                        break;

                    case 4:
                        break;
                    default:
                        Debug.Log("roto");
                        break;
                }
                Destroy(gameObject);
            }
            else{
             
                switch (type)
                {
                    case 1:
                        collision.GetComponent<IAEnemigo>().HealthUp();
                        break;

                    case 2:
                        collision.GetComponent<IAEnemigo>().speedUp();
                        break;

                    case 3:
                        collision.GetComponent<IAEnemigo>().reduceCooldown();
                        break;

                    case 4:
                        break;
                    default:
                        Debug.Log("roto");
                        break;
                }
                Destroy(gameObject);


            }
        }
    }


}