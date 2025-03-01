using UnityEngine;

public class robot_move : MonoBehaviour
{
    float speedX;
    float speedY;
    public float speed;
    Rigidbody2D rb;
    private bool isFacingRight = true;
    public float jump;

    public Transform inGround;
    public LayerMask groundLayer;
    bool isGrounded;

    public float gravityScale = 3f; // Adjust gravity scale here

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;  // Apply gravity scale
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(inGround.position, new Vector2(2.5f, 1.0f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        speedX = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jump), ForceMode2D.Impulse);
        }

        rb.linearVelocity = new Vector2(speedX, rb.linearVelocity.y); // Maintain vertical velocity
        Flip();
    }

    private void Flip()
    {
        if (isFacingRight && speedX > 0f || !isFacingRight && speedX < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
