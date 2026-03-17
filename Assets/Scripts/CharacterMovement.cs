using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody rb;

    Vector3 moveVectorInput;
    Vector3 moveDirection;
    Vector3 rotationDirection; 
    [SerializeField] float speed = 10f;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] Camera targetCamera;
    Animate animate;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animate = GetComponentInChildren<Animate>();
    }
    public void AddMoveVectorInput(Vector3 moveVector)
    {
        moveVectorInput = moveVector;
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleAnimation();
    }

    private void HandleAnimation()
    {
        animate.motion = moveVectorInput.magnitude;
    }
    private void HandleMovement()
    {
        //moveDirection = moveVectorInput;
        moveDirection = targetCamera.transform.forward * moveVectorInput.y;
        moveDirection += targetCamera.transform.right * moveVectorInput.x;
        moveDirection.y = 0f;
        moveDirection.Normalize();

        Vector3 moveVelocity = moveDirection * speed;
        moveVelocity += Physics.gravity;

        rb.velocity = moveVelocity;
    }

    private void HandleRotation()
    {
        if(moveDirection.magnitude > 0f)
        {
            rotationDirection = moveDirection;

        }
        if (rotationDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(rotationDirection);
            Quaternion rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            transform.rotation = rotation;

        }
    }
}
