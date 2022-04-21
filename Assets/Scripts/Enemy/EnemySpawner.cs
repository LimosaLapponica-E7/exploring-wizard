using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject slime;
    [SerializeField] float slimeRate; //how many we want to spawn per minute, theoretically can be changed midgame

    [SerializeField] GameObject bird;
    [SerializeField] Transform player;
    [SerializeField] private int minDistFromPlayer;
    [SerializeField] private int maxDistFromPlayer;
    [SerializeField] float birdRate; //flocks per minute, will want to be able to change how many members of the flock we want

    private float timesincebird = 0.0f;
    private float timesinceslime = 0.0f;

    void spawnSlime()
    {
        Instantiate(slime, randomSpawn(), Quaternion.identity);
        timesinceslime = 0;
    }

    void spawnBird()
    {
        Instantiate(bird, randomSpawn(), Quaternion.identity);
        timesincebird = 0;
    }

    Vector2 randomSpawn()
    {
        return new Vector2(player.position.x + Random.Range(minDistFromPlayer, maxDistFromPlayer),
           player.position.y + Random.Range(minDistFromPlayer, maxDistFromPlayer));
    }

    // Update is called once per frame
    void Update()
    {
        timesinceslime += Time.deltaTime;
        timesincebird += Time.deltaTime;

        if (timesinceslime > (60 / slimeRate))
            spawnSlime();

        if (timesincebird > (60 / birdRate))
            spawnBird();

    }
}
