using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody rb;

    Vector3 moveVectorInput;

    [SerializeField] float speed = 10f;
    [SerializeField] float rotationSpeed = 180f;

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
        HandleAnimation();
    }

    private void FixedUpdate()
    {
        HandleRotation();
        HandleMovement();
    }

    private void HandleAnimation()
    {
        float forwardInput = moveVectorInput.y;

        if (Mathf.Abs(forwardInput) < 0.2f)
            forwardInput = 0f;

        animate.motion = Mathf.Abs(forwardInput);
    }

    private void HandleRotation()
    {
        float turnInput = moveVectorInput.x;

        // 미세 입력 무시
        if (Mathf.Abs(turnInput) < 0.2f)
            turnInput = 0f;

        if (turnInput != 0f)
        {
            float turnAmount = turnInput * rotationSpeed * Time.fixedDeltaTime;
            transform.Rotate(0f, turnAmount, 0f);
        }
    }

    private void HandleMovement()
    {
        float forwardInput = moveVectorInput.y;

        // 미세 입력 무시
        if (Mathf.Abs(forwardInput) < 0.2f)
            forwardInput = 0f;

        Vector3 moveDirection = transform.forward * forwardInput * speed;
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);
    }
}