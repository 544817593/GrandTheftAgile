using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float speed = 5f;

    private Transform target;
    private int pathIndex = 0;

    private void Start()
    {
        target = LevelManager.Instance.path[0];
    }

    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;

            if (pathIndex == LevelManager.Instance.path.Length)
            {
                EnemySpawner.onEnemyDestory.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.Instance.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }
}
