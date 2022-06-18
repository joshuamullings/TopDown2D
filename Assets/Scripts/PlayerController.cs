using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5.0f;

    private new Rigidbody2D rigidbody2D;
    private Vector2 movement;
    private Vector2 previousPosition;
    private Vector2 newPosition;
    private Vector2 velocity;

    public Vector2 GetVelocity => velocity;

    private void Start() 
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        previousPosition = transform.position;
        newPosition = transform.position;
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        CalculateVelocity();
    }

    private void GetInput()
    {
        Vector2 movementInput = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movement.x = movementSpeed * movementInput.x;
        movement.y = movementSpeed * movementInput.y;
    }

    private void MovePlayer()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + (movement * movementSpeed * Time.fixedDeltaTime));
    }

    private void CalculateVelocity()
    {
        newPosition = transform.position;
        velocity = (newPosition - previousPosition) / Time.fixedDeltaTime;
        previousPosition = newPosition;
    }
}
