using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpForce = 5f;
    public float detectionRange = 5f;
    public float attackRange = 1f;
    public float attackCooldown = 2f;
    public float timeBetweenJumps = 1f;

    private Transform player;
    private Rigidbody2D rb;
    private bool isAttacking;
    private float currentTime;

    public LayerMask groundLayer;

    void Start()
    {
        currentTime = timeBetweenJumps;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            if (distanceToPlayer <= attackRange && !isAttacking)
            {
                StartCoroutine(AttackPlayer());
            }
            else
            {
                MoveTowardsPlayer();
            }
        }

        Debug.Log(IsGrounded());
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);

        if (IsGrounded() && currentTime <= 0.0f)
        {
            Jump();
            currentTime = timeBetweenJumps;
        }

        currentTime -= Time.deltaTime;
    }

    void Jump()
    {
        Debug.Log("Jumped");
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, groundLayer);
        return hit.collider != null;
    }

    IEnumerator AttackPlayer()
    {
        isAttacking = true;
        Debug.Log("Slime Attacked");

        yield return new WaitForSeconds(attackCooldown);

        isAttacking = false;
    }
}
