using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public GameObject bullet;

    private GameObject playerGameObject;
    private Transform bulletStorageTransform;
    private readonly float timeBetweenShots = 0.3f;
    private float shotTimer;

    private void Start()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        bulletStorageTransform = GameObject.FindGameObjectWithTag("Bullet Storage").transform;
        shotTimer = timeBetweenShots;
    }

    private void Update()
    {
        shotTimer -= Time.deltaTime;

        if (shotTimer <= 0.0f && Input.GetKey(KeyCode.Mouse0))
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        // get player to mouse angle
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerToMouseVector = mousePosition - playerGameObject.transform.position;
        Quaternion playerToMouseQuaternion = Quaternion.Euler(0.0f, 0.0f, Vector2.SignedAngle(Vector2.up, playerToMouseVector));

        // instantiate a new bullet at the player, heading towards the mouse
        GameObject newBullet = Instantiate(bullet, playerGameObject.transform.position, playerToMouseQuaternion);
        newBullet.GetComponent<Rigidbody2D>().AddForce(playerToMouseVector * newBullet.GetComponent<Bullet>().initialForce);
        newBullet.transform.SetParent(bulletStorageTransform);
        shotTimer = timeBetweenShots;
    }
}