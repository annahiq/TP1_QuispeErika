using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 4.5f;

    private Rigidbody rb;
    private bool isGrounded;
    private bool jumpPressed;

    public Transform cameraTransform;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        float movementZ = Input.GetAxisRaw("Vertical");
        float movementX = Input.GetAxisRaw("Horizontal");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 movement = forward * movementZ + right * movementX;

        movement.Normalize();

        Vector3 movementAmount = movement * speed * Time.deltaTime;

        rb.MovePosition(rb.position + movementAmount);

        if (jumpPressed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpPressed = false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}