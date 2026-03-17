using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputProcess : MonoBehaviour
{
    CharacterMovement characterMovement;
    CharacterInteract characterInteract;
    Vector3 moveVector;

    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
        characterInteract = GetComponent<CharacterInteract>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        characterMovement.AddMoveVectorInput(moveVector);
    }

    public void ProcessMoveInput(CallbackContext callbackContext)
    {
        moveVector = callbackContext.ReadValue<Vector2>();
    }


    public void ProcessInteractInput(CallbackContext callbackContext)
    {
        if(callbackContext.phase == UnityEngine.InputSystem.InputActionPhase.Started)
        {
            characterInteract.Interact();
        }
  
    }
}
