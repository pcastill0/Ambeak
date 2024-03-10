using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    public Animator humo;
    public GameObject owner;

    public GameManager manager;
    public AudioClip sonidoMina;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sonidoMina;
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
                collision.GetComponent<Hearts>().modifyHealth(-2);
           
                Animator a = Instantiate(humo, transform.position, Quaternion.identity);
                CameraShake.Shake(0.5f, 1f);

                manager.reproducirMina();
                audioSource.Play();

                Destroy(a, 1.64f);
                Destroy(this.gameObject);

            }
        }
    }

}
