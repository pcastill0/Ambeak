using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class GameManager : MonoBehaviour
{
    float counter = 0;
    public GameObject powerUp1;
    public GameObject powerUp2;
    public GameObject powerUp3;

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
            GameObject power;
            int rand = Random.Range(0, 3);
            counter = 0;
            switch (rand) { 
                case 0:
                    power = Instantiate(powerUp1, transform.position, transform.rotation);
                    power.transform.position = new Vector2(Random.Range(-9, 9), Random.Range(-4, 4));
                    break;
                case 1:
                    power = Instantiate(powerUp2, transform.position, transform.rotation);
                    power.transform.position = new Vector2(Random.Range(-9, 9), Random.Range(-4, 4));
                    break; 
                case 2:
                    power = Instantiate(powerUp3, transform.position, transform.rotation);
                    power.transform.position = new Vector2(Random.Range(-9, 9), Random.Range(-4, 4));
                    break;
            }
            
            
        }
    }
}
