using UnityEngine;

public class Testing : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded;
    private int jumpCount = 0;
    private int maxJumps = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ);
        rb.linearVelocity = new Vector3(move.x * speed, rb.linearVelocity.y, move.z * speed);

        
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);

        if (isGrounded)
        {
            jumpCount = 0;

            if (Input.GetButtonDown("jump") && jumpCount < maxJumps)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumpCount++;
            }
            else if (Input.GetButtonDown("jump") && jumpCount >= maxJumps)
            {
                jumpCount = 0;
            }

        }
    }

    // void OnCollisionStay(Collision collision)
    // {
      
    //     if (((1 << collision.gameObject.layer) & groundLayer) != 0)
    //     {
    //         isGrounded = true;
    //     }
    // }
}
