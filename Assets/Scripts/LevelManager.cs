using UnityEngine;


public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Transform startPoint;
    public Transform[] path;

    public int currency;
    public int playerHealth;
    public int playerScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currency = 100;
        playerHealth = 10;
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool DecreaseCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("Not enough currency!");
            return false;
        }

    }

    public bool DecreasePlayerHealth(int amount)
    {
        playerHealth -= amount;
        if (playerHealth <= 0)
        {
            Debug.Log("Game Over!");
            return true;
        }
        return false;
    }
}
