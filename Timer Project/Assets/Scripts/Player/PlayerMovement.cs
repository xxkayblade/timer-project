using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Speed")]
    public float playerSpeed = 1f;


    // FixedUpdate is called every physics update
    private void FixedUpdate()
    {
        // finds current player input
        Vector3 currentDirection = Direction();
        // throw into translate and multiply by acceleration
        transform.Translate(Direction() * playerSpeed);
    }

    // gets input from keyboard -- WASD
    // obtains direction and returns as vector
    public Vector3 Direction()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        // constructs vector based on x and y axis 
        Vector3 direction = new Vector3 (hInput, vInput, 0);
        return direction;
    }

    /*// checking for enemy and projectile collision 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyProjectile")
        {
            Destroy(this);
            Debug.Log("you died!");
        }

        Debug.Log("collided with " + collision.gameObject.name);
        // you died by "this" screen?

    }*/

}
