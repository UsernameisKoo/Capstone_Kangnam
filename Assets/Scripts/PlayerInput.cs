using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    CharacterMovement characterMovement;
    CharacterInteract characterInteract;
    Vector3 moveVector;

    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
        characterInteract = GetComponent<CharacterInteract>(); ;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.z = Input.GetAxisRaw("Vertical");

        characterMovement.AddMoveVectorInput(moveVector);

        if(Input.GetMouseButtonDown(1)) { 
            characterInteract.Interact();
        }
    }
}
