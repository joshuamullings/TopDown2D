using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float movementSpeed = 2.0f;

    private Transform playerTransform;
    private new Rigidbody2D rigidbody2D;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        if (Vector2.Distance(playerTransform.position, transform.position) > 1.0f)
        {
            Vector2 enemyToPlayerVector = (Vector2)playerTransform.position - rigidbody2D.position;
            rigidbody2D.MovePosition(rigidbody2D.position + (movementSpeed * enemyToPlayerVector.normalized * Time.fixedDeltaTime));
        }
    }
}
