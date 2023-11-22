using UnityEngine;

public class PlayerWallJump : MonoBehaviour
{
    [SerializeField] PlayerMovement _playerMovementScript;
    [SerializeField] Transform wallCheck;

    public float wallSlideSpeed = 1f;
    public LayerMask wallLayer;

    private bool isWallSliding;

    public bool isWallJumping;
    private float wallJumpDirection;
    public float wallJumpTime;
    private float wallJumpCounter;
    private float wallJumpingDuration = 0.4f;
    public Vector2  wallJumpPower = new Vector2(0f, 16f);

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleWallSlide();
        WallJumpAction();
    }

    bool CheckWallCollision()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    void HandleWallSlide()
    {
        if (CheckWallCollision() && !_playerMovementScript.IsGrounded())
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    void WallJumpAction()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpDirection = -transform.localScale.x;
            wallJumpCounter = wallJumpTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpCounter -= Time.deltaTime;
        }

        if(Input.GetButtonDown("Jump") && wallJumpCounter > 0.0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpDirection * wallJumpPower.x, wallJumpPower.y);
            wallJumpCounter = 0.0f;
            
            if(transform.localScale.x != wallJumpDirection)
            {
                _playerMovementScript.isFacingRight = !_playerMovementScript.isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    void StopWallJumping()
    {
        isWallJumping = false;
    }
}
