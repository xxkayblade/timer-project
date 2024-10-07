using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [Header("Player Reference")]
    public GameObject player;
    PlayerMovement playerScript;

    [Header("Enemy Atrributes")]
    [SerializeField] float enemySpeed;

    [Header("Audio")]
    public AudioSource source;
    public AudioClip bubbleClip; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerMovement>();   
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 distance = (player.transform.position - transform.position).normalized;

            transform.position += distance * enemySpeed * Time.deltaTime;
        }
    }

    // checking for enemy and projectile collision 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            source.PlayOneShot(bubbleClip);

            Destroy(collision.gameObject);
            DetectKill();
        }
    }

    void DetectKill()
    {
        playerScript.TrackEnemiesDefeated();
        Destroy(gameObject, 0.1f);
    }
}
