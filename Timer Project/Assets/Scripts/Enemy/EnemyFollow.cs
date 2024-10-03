using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : Enemy
{
    [Header("Player Reference")]
    public GameObject player;

    [Header("Enemy Atrributes")]
    [SerializeField] float enemySpeed;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
      Vector3 distance = (player.transform.position - transform.position).normalized;

        transform.position += distance * enemySpeed * Time.deltaTime;
    }
}
