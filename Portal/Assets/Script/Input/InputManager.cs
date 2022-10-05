using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerControl playerControl;

    private Vector2 Movement;

    public PlayerController playerController;

    

    private void Awake()
    {
        playerControl = new PlayerControl();
        playerControl.MovementAction.Movement.performed += wasdClicked;
        playerControl.MovementAction.Jump.performed += jumpClicked;

        playerControl.MovementAction.MouseX.performed += MouseXClicked;
        playerControl.MovementAction.MouseY.performed += MouseYClicked;
    }

    private void wasdClicked(InputAction.CallbackContext obj)
    {
        playerController.IHorizontalMovement = obj.ReadValue<Vector2>();
    }   
    private void jumpClicked(InputAction.CallbackContext obj)
    {
        playerController.IJump = true;
    }

    private void MouseXClicked(InputAction.CallbackContext obj)
    {
        playerController.IMouseX = obj.ReadValue<float>();
    }
    private void MouseYClicked(InputAction.CallbackContext obj)
    {
        playerController.IMouseY = obj.ReadValue<float>();
    }
    private void OnEnable()
    {
        playerControl.Enable();
    }
    private void OnDisable()
    {
        playerControl.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
