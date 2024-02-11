using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class GameManager : MonoBehaviour
{
    float counter = 0;
    public GameObject powerUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > 3)
        {
            counter = 0;
            GameObject power = Instantiate(powerUp, transform.position, transform.rotation);
            power.transform.position = new Vector2(Random.Range(-9, 9), Random.Range(-4, 4));
            Debug.Log(power.GetComponent<PowerUps>().type);
            switch (power.GetComponent<PowerUps>().type)
            {
                case 1:
                    Debug.Log("11");
                    power.GetComponent<SpriteRenderer>().color = new Color(219f, 0f, 0f, 255f);
                    break;

                case 2:
                    Debug.Log("22");
                    break;

                case 3:
                    Debug.Log("33");
                    power.GetComponent<SpriteRenderer>().color = new Color(9f, 255f, 82f, 255f);
                    break;

                case 4:
                    Debug.Log("44");
                    power.GetComponent<SpriteRenderer>().color = new Color(9f, 255f, 251f, 255f);
                    break;
                default:
                    Debug.Log("roto");
                    break;
            }
        }
    }
}
