using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    private GameObject playerGameObject;
    private readonly float detectionRange = 1000.0f;

    private void Start()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
    }
    
    private GameObject FindNearestEnemy()
    {
        GameObject[] enemyGameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        Vector2 playerPosition = playerGameObject.transform.position;
        float distance = float.PositiveInfinity;

        foreach (GameObject enemy in enemyGameObjects)
        {
            float currentDistance = ((Vector2)enemy.transform.position - playerPosition).sqrMagnitude;
            if (currentDistance <= detectionRange && currentDistance <= distance)
            {
                nearestEnemy = enemy;
                distance = currentDistance;
            }
        }

        return nearestEnemy;
    }
}