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
        Debug.Log(playerInput);
        Player[] players = FindObjectsOfType<Player>();
        int index = playerInput.playerIndex;
        Debug.Log(playerInput.devices[0].name);
        if (playerInput.devices[0].name == "XInputControllerWindows") {
            Destroy(gameObject);
        }
       
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

    public void OnTrap3(CallbackContext context)
    {
        if (player != null)
        {
            player.trap3Pressed(context.action.triggered);
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

    public void OnPause(CallbackContext context)
    {
        if (player != null)
        {
            player.onPause(context.action.triggered);
        }
    }
    /*
    public void OnTrap4(CallbackContext context)
    {
        if(player != null)
        {
            player.trap4Pressed(context.action.triggered);
        }
    }
    */

}
