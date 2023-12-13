using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Inventory))]
public class Movement : MonoBehaviour
{
    [SerializeField]
    private Transform groundCheckTransform;

    [SerializeField]
    private LayerMask groundLayer;

    private Animator animator;
    private new Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private Inventory inventory;

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpForce = 8f;
    [SerializeField]
    private float jumpAdditionalForce = 0.75f;
    [SerializeField]
    private float maxJumpTime = 0.8f;

    private bool isGrounded;
    private float jumpTimer;

    private void Update()
    {
        if (LevelData.Instance.IsGameFinished)
        {
            return;
        }

        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0f)
        {
            spriteRenderer.flipX = horizontalInput > 0;

            inventory.Flip(spriteRenderer.flipX);

            transform.Translate(new Vector3(horizontalInput, 0, 0) * speed * Time.deltaTime);
        }

        isGrounded = Physics2D.Raycast(groundCheckTransform.position, Vector2.down, 0.1f, groundLayer);

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
        inventory = GetComponent<Inventory>();
    }
}
