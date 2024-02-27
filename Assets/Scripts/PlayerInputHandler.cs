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
    
    private void Awake()
    {
        Debug.Log("perro");
        playerInput = GetComponent<PlayerInput>();
        Player[] players = FindObjectsOfType<Player>();
        int index = playerInput.playerIndex;
        player = players.FirstOrDefault(m => m.playerIndex == index);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTrap1(CallbackContext context)
    {
        if (player != null)
        {
            player.trap1Pressed(context.action.triggered);
        }
    }

    public void OnTrap2(CallbackContext context)
    {
        if (player != null)
        {
            player.trap2Pressed(context.action.triggered);
        }
    }

    public void OnStun(CallbackContext context)
    {
        if (player != null)
        {
            player.stunPressed(context.action.triggered);
        }
    }

    public void OnMove(CallbackContext context)
    {
        if (player != null)
        {
            player.SetInputVector(context.ReadValue<Vector2>());
        }
    }

}
