using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundMask;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private float gravity = -9.81f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        // Freeze rotation completely
        transform.rotation = Quaternion.identity;
    }

    void Update()
    {
        // Always reset rotation (stop any turning)
        transform.rotation = Quaternion.identity;

        // Check ground
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // No rotation applied — just move forward/backward/left/right
        Vector3 move = new Vector3(x, 0, z);
        controller.Move(transform.TransformDirection(move) * speed * Time.deltaTime);

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
