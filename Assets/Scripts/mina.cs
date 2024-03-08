using UnityEngine;

public class Mina : MonoBehaviour
{
    public GameObject owner;
    public GameManager manager;

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
                heartsComponent.health -= 1;

                // Calcular la dirección opuesta al vector de la mina
                Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;

                // Aplicar una fuerza para hacer saltar hacia atrás al jugador
                Rigidbody2D playerRigidbody = collision.GetComponent<Rigidbody2D>();
                if (playerRigidbody != null)
                {
                    float knockbackForce = 10f; // Puedes ajustar la fuerza según sea necesario
                    playerRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
                }
            }

            Destroy(gameObject);
        }
    }
}
