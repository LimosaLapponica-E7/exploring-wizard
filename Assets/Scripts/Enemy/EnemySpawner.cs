using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float enemyRate; //how many we want to spawn per minute, theoretically can be changed midgame
    [SerializeField] Transform player;
    [SerializeField] private int minDistFromPlayer;
    [SerializeField] private int maxDistFromPlayer;
    private float timeSinceEnemy = 0.0f;

    void spawnEnemy()
    {
        Instantiate(enemy, randomSpawn(), Quaternion.identity);
        timeSinceEnemy = 0;
    }

    Vector2 randomSpawn()
    {
        return new Vector2(player.position.x + Random.Range(minDistFromPlayer, maxDistFromPlayer),
           player.position.y + Random.Range(minDistFromPlayer, maxDistFromPlayer));
    }

    void Update()
    {
        timeSinceEnemy += Time.deltaTime;

        if (timeSinceEnemy > (60 / enemyRate))
            spawnEnemy();
    }
}
