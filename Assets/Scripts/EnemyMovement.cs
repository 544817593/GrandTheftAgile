using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float speed = 1f;
    [SerializeField] private int scoreValue = 1;
    [SerializeField] private string enemyTag;

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
                if (LevelManager.Instance.playerHealth > 0)
                {
                    LevelManager.Instance.DecreasePlayerHealth(1);
                }
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

    public int GetScore()
    {
         return scoreValue; 
    }

    public string GetEnemyTag()
    {
        return enemyTag;
    }
}
