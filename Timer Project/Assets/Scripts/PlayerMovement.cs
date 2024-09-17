using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Acceleration")]
    public float accel = 1f;
    public float hAccel = 1f;
    public float vAccel = .1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // FixedUpdate is called every physics update
    private void FixedUpdate()
    {
        // finds current player input
        Vector3 currentDirection = Direction();
        currentDirection.x = hAccel;
        currentDirection.y = vAccel;

        // throw into translate and multiply by acceleration
        transform.Translate(Direction() * accel);

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

    // checking for enemy and projectile collision 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("oops player dead");

        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "projectile")
        {
            Destroy(this.gameObject);
        }
    }

}
