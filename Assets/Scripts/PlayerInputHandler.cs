using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private Player player;
    private Mover mover;
    
    private void Awake()
    {
        Debug.Log("perro");
        playerInput = GetComponent<PlayerInput>();
        var players = FindObjectsOfType<Player>();
        var index = playerInput.playerIndex;
        player = players.FirstOrDefault(m => m.GetPlayerIndex() == index);
    }
    /*
    private void Awake()
    {
        Debug.Log("perro");
        playerInput = GetComponent<PlayerInput>();
        var index = playerInput.playerIndex;
        var movers = FindObjectsOfType<Mover>();
        mover = movers.FirstOrDefault(m => m.GetPlayerIndex() == index);
    }*/
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("perroo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTrap(CallbackContext context)
    {
        Debug.Log("perrooo");
        
        if (player != null)
        {
            player.trap1Pressed(context.action.triggered);
        }
            /*
        if (mover != null)
            mover.SetInputVector(context.ReadValue<Vector2>());*/
    }

    public void OnMove(CallbackContext context)
    {
        if (player != null)
        {
            player.SetInputVector(context.ReadValue<Vector2>());
        }
    }

}
