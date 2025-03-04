using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;

    private bool isDestroyed = false;

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestory.Invoke();
            isDestroyed = true;
            LevelManager.Instance.playerScore += gameObject.GetComponent<EnemyMovement>().GetScore();
            Destroy(gameObject);
        }
    }
}
