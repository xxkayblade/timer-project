using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Game Manager")]
    [SerializeField] GameManager gameManager;
    
    [Header("Player Attributes")]
    public float playerSpeed = 1f;
    Rigidbody2D playerRB;
    private Vector2 moveDirection;

    [Header("Aim")]
    public Camera mainCamera;
    private Vector2 mousePosition;
    public ShootController shooter;

    [Header("Track Score")]
    public int enemiesDefeated = 0;

    [Header("Audio")]
    public AudioSource source;
    public AudioClip laserClip;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(hInput, vInput).normalized;

        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            shooter.ShootBullet();
            source.PlayOneShot(laserClip);
        }
    }

    private void FixedUpdate()
    {
        Movement(); 
    }

    void Movement()
    {
        playerRB.velocity = new Vector2(moveDirection.x, moveDirection.y) * playerSpeed;

        Vector2 aimDirection = mousePosition - playerRB.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        playerRB.rotation = angle;
    }

    /*// FixedUpdate is called every physics update
    void FixedUpdate()
    {
        // finds current player input
        Vector3 currentDirection = Direction();
        // throw into translate and multiply by acceleration
        transform.Translate(currentDirection * playerSpeed * Time.fixedDeltaTime);
    }

    // gets input from keyboard -- WASD
    // obtains direction and returns as vector
    public Vector3 Direction()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        // constructs vector based on x and y axis 
        Vector3 direction = new Vector3 (hInput, vInput, 0).normalized;
        return direction;
    }*/

    // checking for enemy and projectile collision 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyProjectile")
        {
            Destroy(gameObject);
            gameManager.gameOverMenu.SetActive(true);
            Debug.Log("you died!");
        }

        Debug.Log("collided with " + collision.gameObject.name);
        // you died by "this" screen?
    }

    public void TrackEnemiesDefeated()
    {
        enemiesDefeated++;
    }

}
