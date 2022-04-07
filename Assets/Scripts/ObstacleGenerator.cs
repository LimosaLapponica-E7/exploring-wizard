using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

    [Range(0,10)] public float obstacleDensity;

    [SerializeField] private SpriteRenderer terrain;

    [SerializeField] private GameObject[] obstacles;

    [SerializeField] private GameObject player;

    [SerializeField] private float minDistFromPlayer;
   

    void Start()
    {

        float cornerX = terrain.bounds.size.x / 2;
        float cornerY = terrain.bounds.size.y / 2;
        int numberOfObstacles = (int) (terrain.bounds.size.x * 
            terrain.bounds.size.y * 0.01 * obstacleDensity);
        Vector2[] obstacleMap = new Vector2[numberOfObstacles];

        for (int i = 0; i < numberOfObstacles; i++)
        {
            GameObject obstaclePrefab = obstacles[Random.Range(0, obstacles.Length)];
            GameObject newObstacle = Instantiate(obstaclePrefab,
                randomPos(minDistFromPlayer, i), Quaternion.identity);
            newObstacle.transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
        }

        Debug.Log( 0.01*(10 - obstacleDensity));

        Vector2 randomPos(float minDistance, int i)
        {
            int limitCount = 0;
            Vector2 obstaclePos;
            do
            {
                obstaclePos = new Vector2(Random.Range(-cornerX, cornerX),
                Random.Range(-cornerY, cornerY));
                obstacleMap[i] = obstaclePos;
                limitCount++;
                if (limitCount > 20000) {
                    Debug.Log("Too many obstacles");
                    break;
                }

            }
            while (Vector2.Distance(obstaclePos, player.transform.position) < minDistance
            || spaceUsed(obstaclePos, i));
            return obstaclePos;
        }

        bool spaceUsed(Vector2 obstaclePos, int end)
        {
            bool spaceUsed = false;
            for (int i = 0; i < end; i++)
            {
                if (Vector2.Distance(obstaclePos, obstacleMap[i]) < Mathf.Clamp(0.5f * (10 - obstacleDensity), 2f, 6f))
                {
                    spaceUsed = true;
                    break;
                }

            }
            return spaceUsed;
        }
    
    }

    void Update()
    {

    }
}
