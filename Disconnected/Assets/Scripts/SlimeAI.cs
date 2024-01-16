using System.Collections;
using UnityEngine;

public class SlimeAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectionRange = 5f;
    public float attackRange = 1f;
    public float attackCooldown = 2f;

    private Transform player;
    private Rigidbody2D rb;
    private bool isAttacking;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        while (true)
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

            yield return new WaitForSeconds(0.5f);
        }
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
    }

    IEnumerator AttackPlayer()
    {
        isAttacking = true;
        // Add your attack animation or logic here

        yield return new WaitForSeconds(attackCooldown);

        isAttacking = false;
    }
}
