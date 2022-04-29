using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockSpawner : MonoBehaviour
{
    [SerializeField] GameObject flock;
    [SerializeField] float flockRate;
    [SerializeField] Transform player;
    [SerializeField] private int minDistFromPlayer;
    [SerializeField] private int maxDistFromPlayer;

    private float timeSinceFlock = 0.0f;

    void spawnFlock()
    {
        Instantiate(flock, randomSpawn(), Quaternion.identity);
        timeSinceFlock = 0;
    }

    Vector2 randomSpawn()
    {
        return new Vector2(player.position.x + Random.Range(minDistFromPlayer, maxDistFromPlayer),
           player.position.y + Random.Range(minDistFromPlayer, maxDistFromPlayer));
    }
    void Update()
    {
        timeSinceFlock += Time.deltaTime;

        if (timeSinceFlock > (60 / flockRate))
            spawnFlock();

    }
}
