using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 4f;
    private Rigidbody rb;
    private bool isGrounded;
    private bool jumpPressed;

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
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementZ = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(movementX, 0f, movementZ).normalized;
        Vector3 movementAmount = movement * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movementAmount);

        if (Input.GetKey(KeyCode.Space))
        {
        rb.AddForce(Vector3.up * jumpForce);
        }
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