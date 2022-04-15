using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject slime;
    [SerializeField] float slimeRate; //how many we want to spawn per minute, theoretically can be changed midgame

    [SerializeField] GameObject bird;
    [SerializeField] float birdRate; //flocks per minute, will want to be able to change how many members of the flock we want

    private float timesincebird = 0.0f;
    private float timesinceslime = 0.0f;

    void spawnSlime()
    {
        Vector2 randomPoint = Random.insideUnitCircle * 200;
        Instantiate(slime, randomPoint, Quaternion.identity);
        timesinceslime = 0;
    }

    void spawnBird()
    {
        Vector2 randomPoint = Random.insideUnitCircle * 200;
        Instantiate(bird, randomPoint, Quaternion.identity);
        timesincebird = 0;
    }


    // Start is called before the first frame update
    void Start()
    {

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
