using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float speed;
    public int type;

    //public string inputStun;

    public GameObject trap1;
    public GameObject trap2;
    public GameObject stun1;
    public GameObject empujeTrap;
    public GameObject stunEffect;
    public GameObject clonBomba;

    public bool isPlayerStunned = false;
    public bool isDead;

    public float cooldownTrap1 = 5f;
    public float cooldownTrap2 = 5f;
    public float cooldownTrap3 = 5f;
    public float cooldownTrap4 = 0f;

    float countertrap1 = 4;
    float countertrap2 = 4;
    float countertrap3 = 4;
    float countertrap4 = 4;

    float holeCooldown = 3;
    bool bajoTierra = false;

    float stunCooldown = 5;
    float stunCounter= 0;

    float stunnedCooldown = 3;
    float stunnedCounter = 0;

    private float limiteXpos = 10;
    private float limiteXneg = -10;
    private float limiteYpos = 5;
    private float limiteYneg = -5;


    public Animator animator;
    public GameObject pausaMenuUI;
    public GameObject restart;
    public GameObject exit;
    public GameObject info;
    public GameObject menu;

    Color playerCol;

    public int playerIndex = 0;

    private Vector2 movementInput = Vector2.zero;
    private cuenta_atras cuentaAtrasScript;

    void Start()
    {
        playerCol = gameObject.GetComponent<SpriteRenderer>().color;
        isDead = false;
    }


    void Update()
    {

        if (isDead)
        {
            gameObject.GetComponent<Player>().enabled = false;
        }

        //MOVIMIENTO PLAYER
        if(isPlayerStunned && stunnedCounter > stunnedCooldown)
        {
            isPlayerStunned = false;
            stunnedCounter = 0;
            stunEffect.SetActive(false);
        }

        if (!isPlayerStunned)
        {
            transform.position += new Vector3(movementInput.x, movementInput.y, 0) * Time.deltaTime * speed;
        }

        //CONTADORES
        countertrap1 += Time.deltaTime;
        countertrap2 += Time.deltaTime;
        countertrap3 += Time.deltaTime;
        countertrap4 += Time.deltaTime;
        stunCounter += Time.deltaTime;


        if(isPlayerStunned){
            stunnedCounter += Time.deltaTime;
        }

        //CONTADOR CDR
        if (gameObject.GetComponent<BoxCollider2D>().enabled == false)
        {
            holeCooldown -= Time.deltaTime;
        }

        //COMPROBACION TIEMPO (GUJERO)
        if (holeCooldown <= 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().color = playerCol;
            holeCooldown = 3;
            GameObject trap3 = Instantiate(trap2, transform.position, transform.rotation);
            trap3.GetComponent<HoleTrap>().owner = gameObject;
            Destroy(trap3, 2);
            bajoTierra = false;
        }

        //LIMITES MOVIMIENTO
        if (transform.position.x < limiteXneg)
        {
            transform.position = new Vector3(limiteXneg, transform.position.y, 0);
        }
        if (transform.position.x > limiteXpos)
        {
            transform.position = new Vector3(limiteXpos, transform.position.y, 0);
        }
        if (transform.position.y < limiteYneg)
        {
            transform.position = new Vector3(transform.position.x, limiteYneg, 0);
        }
        if (transform.position.y > limiteYpos)
        {
            transform.position = new Vector3(transform.position.x, limiteYpos, 0);
        }

        //ANIMACIONES
        if (movementInput.x != 0 || movementInput.y != 0)
        {
            animator.SetFloat("X", movementInput.x);
            animator.SetFloat("Y", movementInput.y);

            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

    }

    public void speedUp()
    {
        StartCoroutine(speedUpCo());
    }
    private IEnumerator speedUpCo()
    {
        speed *= 1.25f;
        yield return new WaitForSeconds(5);
        speed /= 1.25f;
    }

    public void reduceCooldown()
    {
        StartCoroutine(reduceCooldownCo());
    }
    private IEnumerator reduceCooldownCo()
    {
        cooldownTrap1 /= 2f;
        cooldownTrap2 /= 2f;
        cooldownTrap3 /= 2f;
        yield return new WaitForSeconds(7.5f);
        cooldownTrap1 *= 2f;
        cooldownTrap2 *= 2f;
        cooldownTrap3 *= 2f;

    }

    public void trap1Pressed(bool pressed)
    {
        if (pressed && countertrap1 > cooldownTrap1 && !bajoTierra && !isPlayerStunned)
        {
            GameObject trapp = Instantiate(trap1, transform.position, transform.rotation);
            trapp.GetComponent<Trampa>().owner = gameObject;
            countertrap1 = 0;
        }
    }

    public void trap2Pressed(bool pressed)
    {
        if (pressed && countertrap2 > 5 && !bajoTierra && !isPlayerStunned)
        {
            holeCooldown = 3;
            countertrap2 = 0;
            bajoTierra = true;

            GameObject trap = Instantiate(trap2, transform.position, transform.rotation);
            trap.GetComponent<HoleTrap>().owner = gameObject;

            gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, .5f);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void trap3Pressed(bool pressed)
    {
        if (pressed && countertrap3 > cooldownTrap3 && !bajoTierra && !isPlayerStunned)
        {
            GameObject empuje = Instantiate(empujeTrap, transform.position, transform.rotation);
            empuje.GetComponent<Mina>().owner = gameObject;
            countertrap3 = 0;
        }
    }

    public void stunPressed(bool pressed)
    {
        if (pressed && stunCounter > stunCooldown && !bajoTierra && !isPlayerStunned)
        {
            stunCounter = 0;
            if (movementInput.magnitude > 0.01f)
            {
                float angle = Mathf.Atan2(movementInput.x, - (movementInput.y)) * Mathf.Rad2Deg;
                GameObject stun = Instantiate(stun1, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
                stun.GetComponent<Stun>().owner = gameObject;
                Destroy(stun, 0.3f);
            }
            else
            {
                GameObject stun = Instantiate(stun1, transform.position, Quaternion.identity);
                stun.GetComponent<Stun>().owner = gameObject;
                Destroy(stun, 0.3f);
            }
        }
    }

    public void SetInputVector(Vector2 direction)
    {
        movementInput = direction;
    }

    public void onPause(bool pressed)
    {
        Debug.Log("pause");
        if (pressed)
        {
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f; // Reanudar el juego
                restart.SetActive(false);
                exit.SetActive(false);
                info.SetActive(false);
                menu.SetActive(false);
    //pausaMenuUI.SetActive(false);
}
            else
            {
                restart.SetActive(true);
                exit.SetActive(true);
                info.SetActive(true);
                menu.SetActive(true);
                Time.timeScale = 0f;
                /*
                if (cuentaAtrasScript.gameObject.activeSelf)
                {

                    // Si la cuenta atras esta activa, pausar el juego
                    Time.timeScale = 0f;
                    SceneManager.LoadScene("Settings");
                }
                else
                {
                    Time.timeScale = 1f; // Si no, pausar el juego normalmente
                    //pausaMenuUI.SetActive(true);
                }
                */
            }
        }
    }
    
    public void trap4Pressed(bool pressed)
    {

        if (pressed && countertrap4 > cooldownTrap4 && !bajoTierra)
        {
            GameObject clon = Instantiate(clonBomba, transform.position, transform.rotation);
            clon.GetComponent<ClonBomba>().owner = gameObject;
            countertrap4 = 0;
        }
    }



}
