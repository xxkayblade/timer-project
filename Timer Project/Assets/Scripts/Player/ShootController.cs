using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootController : MonoBehaviour
{
    [Header("Bullet Attributes")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed;

    void Update()
    {   
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 shootDirection = (mousePosition - transform.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.velocity = shootDirection * bulletSpeed;
    }
}
