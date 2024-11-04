using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float gravityMultiplier = 2f;
    public bool doubleJump = true;

    private Rigidbody rb;
    private Vector3 moveDirection;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = (transform.right * moveX + transform.forward * moveZ) * moveSpeed;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        } else if (doubleJump == true && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce * 2, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        Vector3 velocity = moveDirection * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + velocity);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
