using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashDistance = 4.3f;
    public float dashCooldown = 2.4f;

    private Rigidbody2D rb;
    private bool canDash = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Change the key check to Right Shift
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            Dash();
        }
    }

    void Dash()
    {
        // Perform the dash
        Vector2 dashDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        Vector2 dashPosition = rb.position + dashDirection * dashDistance;
        rb.MovePosition(dashPosition);

        // Set cooldown
        canDash = false;
        Invoke("ResetDash", dashCooldown);
    }

    void ResetDash()
    {
        canDash = true;
    }
}
