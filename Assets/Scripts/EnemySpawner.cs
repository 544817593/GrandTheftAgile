using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 10;
    [SerializeField] private float enemiesPerSecond = 2;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float diffucultyMultiplier = 0.75f;

    [Header("events")]
    public static UnityEvent onEnemyDestory;

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;

    private void Awake()
    {
        onEnemyDestory = new UnityEvent();
        onEnemyDestory.AddListener(OnEnemyDestroy);
    }

    private void OnEnemyDestroy()
    {
        enemiesAlive--;
    }

    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= 1 / enemiesPerSecond && enemiesLeftToSpawn > 0)
        {
            timeSinceLastSpawn = 0;
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
        }
  

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, diffucultyMultiplier));
    }

    private void SpawnEnemy()
    {
        GameObject enemyPrefab = enemyPrefabs[UnityEngine.Random.Range(0,enemyPrefabs.Length)];
        Instantiate(enemyPrefab, LevelManager.Instance.startPoint.position, Quaternion.identity);
    }
}
