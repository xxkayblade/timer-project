using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [Header("Bullet Attributes")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform fire;
    [SerializeField] float bulletForce;

    public void ShootBullet()
    {
       GameObject bullet = Instantiate(bulletPrefab, fire.position, fire.rotation);
       Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
       bulletRB.AddForce(fire.up * bulletForce, ForceMode2D.Impulse);

       Destroy(bullet, 1f); 
    }
    
    /*[Header("Bullet Attributes")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed;

    [Header("Camera Aim")]
    public Camera mainCamera;
    Vector3 mousePosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 aimDirection = (mousePosition - transform.position).normalized;

        Debug.Log("Mouse Position: " + mousePosition);
        Debug.Log("Shooter Position: " + transform.position);
        Debug.Log("Direction: " + aimDirection);

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.velocity = aimDirection * bulletSpeed;
    }*/

    /*void AimMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 lookDir = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Debug.DrawRay(transform.position, lookDir * 5f, Color.white);
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector3 shootDirection = (mousePosition - transform.position).normalized;

        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        Rigidbody2D playerRB = GetComponentInParent<Rigidbody2D>();
        bulletRB.velocity = shootDirection * bulletSpeed;
        bulletRB.velocity += playerRB.velocity;

    }*/
}
