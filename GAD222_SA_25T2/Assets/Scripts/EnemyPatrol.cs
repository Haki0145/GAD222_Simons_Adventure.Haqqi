using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float groundCheckDistance = 0.5f;
    public LayerMask groundLayer;
    public Transform leftPatrolPoint;
    public Transform rightPatrolPoint;

    private bool movingRight = true;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (leftPatrolPoint == null || rightPatrolPoint == null)
        {
            leftPatrolPoint = new GameObject("LeftBoundary").transform;
            rightPatrolPoint = new GameObject("RightBoundary").transform;

            leftPatrolPoint.position = transform.position - new Vector3(3f, 0, 0);
            rightPatrolPoint.position = transform.position + new Vector3(3f, 0, 0);

            leftPatrolPoint.parent = transform.parent;
            rightPatrolPoint.parent = transform.parent;
        }
    }

    private void Update()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = !movingRight;
        }
    }

    private void FixedUpdate()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (movingRight && transform.position.x >= rightPatrolPoint.position.x)
        {
            movingRight = false;
        }
        else if (!movingRight && transform.position.x <= leftPatrolPoint.position.x)
        {
            movingRight = true;
        }

        if (leftPatrolPoint == null || rightPatrolPoint == null)
        {
            CheckForEdges();
        }

        float moveDirection = movingRight ? 1 : -1;
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
    }

    private void CheckForEdges()
    {
        Vector2 raycastDirection = movingRight ? Vector2.right : Vector2.left;
        Vector2 raycastOrigin = (Vector2)transform.position +
                               (movingRight ? Vector2.right * 0.5f : Vector2.left * 0.5f) +
                               Vector2.down * 0.5f;

        RaycastHit2D groundHit = Physics2D.Raycast(raycastOrigin, Vector2.down, groundCheckDistance, groundLayer);
        RaycastHit2D wallHit = Physics2D.Raycast(raycastOrigin, raycastDirection, 0.2f, groundLayer);

        if (!groundHit.collider || wallHit.collider)
        {
            movingRight = !movingRight;
        }
    }

    private void OnDrawGizmos()
    {
        if (leftPatrolPoint != null && rightPatrolPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(leftPatrolPoint.position, rightPatrolPoint.position);
            Gizmos.DrawSphere(leftPatrolPoint.position, 0.1f);
            Gizmos.DrawSphere(rightPatrolPoint.position, 0.1f);
        }

        Vector2 raycastOrigin = (Vector2)transform.position +
                               (movingRight ? Vector2.right * 0.5f : Vector2.left * 0.5f) +
                               Vector2.down * 0.5f;
        Gizmos.color = Color.green;
        Gizmos.DrawLine(raycastOrigin, raycastOrigin + Vector2.down * groundCheckDistance);
    }
}
