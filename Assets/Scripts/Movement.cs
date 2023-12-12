using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Movement : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Animator animator;
    private new Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;

    public float speed = 5f;
    public float jumpForce = 8f;
    public float jumpAdditionalForce = 0.75f;
    public float maxJumpTime = 0.8f;

    private bool isGrounded;
    private float jumpTimer;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0f)
        {
            spriteRenderer.flipX = horizontalInput > 0;
            transform.Translate(new Vector3(horizontalInput, 0, 0) * speed * Time.deltaTime);
        }

        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            jumpTimer = maxJumpTime;
        }

        if (Input.GetButton("Jump") && jumpTimer > 0f)
        {
            jumpTimer -= Time.deltaTime;
            rigidbody.AddForce(Vector2.up * jumpAdditionalForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
        } else
        {
            jumpTimer = 0;
        }

        if (rigidbody.velocity.y > 0 && !isGrounded)
        {
            animator.Play("Jump");
        } else if (rigidbody.velocity.y < 0f && !isGrounded)
        {
            animator.Play("Fall");
        } else if (horizontalInput != 0)
        {
            animator.Play("Move");
        } else
        {
            animator.Play("Idle");
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
