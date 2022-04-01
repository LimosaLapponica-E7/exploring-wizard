using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

    public int numberOfObstacles;

    [SerializeField] private SpriteRenderer terrain;

    [SerializeField] private GameObject[] obstacles;

    void Start()
    {
        float cornerX = terrain.bounds.size.x/2;
        float cornerY = terrain.bounds.size.y/2;
     
        for (int i = 0; i < numberOfObstacles; i++)
        {
            GameObject obstaclePrefab = obstacles[Random.Range(0, obstacles.Length)];
            GameObject newObstacle = Instantiate(obstaclePrefab,
                new Vector2(Random.Range(-cornerX, cornerX),
             Random.Range(-cornerY, cornerY)), Quaternion.identity);
             newObstacle.transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
        }
    }

    void Update()
    {

    }
}
