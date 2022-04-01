using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject slime;
    [SerializeField] float slimeRate; //how many we want to spawn per minute, theoretically can be changed midgame

    private float timesinceslime = 0.0f;

    void spawnSlime()
    {
        Vector2 randomPoint = Random.insideUnitCircle * 200;
        Instantiate(slime, randomPoint, Quaternion.identity);
        timesinceslime = 0;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timesinceslime += Time.deltaTime;

        if (timesinceslime > (60 / slimeRate))
        {
            spawnSlime();
        }

    }
}
