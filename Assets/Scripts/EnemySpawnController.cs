using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public GameObject enemyParent;
    public GameObject enemyPrefab;
    public int spawnCountLimit = 10;
    public float enemySpawnRate = 5.0f;
    
    private Transform enemyStorageTransform;
    private float spawnTimer;

    private void Start()
    {
        enemyStorageTransform = GameObject.FindGameObjectWithTag("Enemy Storage").transform;
        spawnTimer = enemySpawnRate;
    }

    private void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (enemyParent.transform.childCount < spawnCountLimit)
        {
            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0.0f)
            {
                GameObject spawn = Instantiate(enemyPrefab, GetSpawnArea(), Quaternion.identity);
                spawn.transform.SetParent(enemyStorageTransform);
                spawnTimer = enemySpawnRate;
            }
        }
    }

    private Vector2 GetSpawnArea()
    {
        float yLimit = Camera.main.orthographicSize * 2;
        float xLimit = yLimit * Camera.main.aspect;
        float yVarible = Random.Range(-0.9f, 0.9f);
        float xVarible = Random.Range(-0.9f, 0.9f);
        return new Vector2(0.5f * xVarible * xLimit, 0.5f * yVarible * yLimit);
    }
}
