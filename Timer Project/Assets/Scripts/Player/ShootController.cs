using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [Header("Bullet Attributes")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed;

    void Update()
    {
        AimMouse(); 

        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    void AimMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 lookDir = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        Debug.DrawRay(transform.position, lookDir * 5f, Color.white);
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector3 shootDirection = (mousePosition - transform.position).normalized;

        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.velocity = shootDirection * bulletSpeed;

    }
}
