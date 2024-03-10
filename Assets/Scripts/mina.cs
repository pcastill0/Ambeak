using UnityEngine;

public class Mina : MonoBehaviour
{
    public Animator empujeFX;
    public GameObject owner;
    public GameManager manager;
    public float knockbackForce;

    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject != owner)
        {
            manager.reproducirAudio();
            Hearts heartsComponent = collision.GetComponent<Hearts>();

            if (heartsComponent != null)
            {
                heartsComponent.modifyHealth(-1);

                Animator a = Instantiate(empujeFX, transform.position, Quaternion.identity);
                CameraShake.Shake(0.5f, 1f);
               

             
                Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;

                
                Rigidbody2D playerRigidbody = collision.GetComponent<Rigidbody2D>();
                if (playerRigidbody != null)
                {
                    knockbackForce = 10f; 
                    playerRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
                }
            }
            

            Destroy(gameObject);
        }
    }
}
