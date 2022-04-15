using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

    [Range(0,10)] public float obstacleDensity;

    [SerializeField] private SpriteRenderer terrain;

    [SerializeField] private Transform terrainTransform;

    [SerializeField] private GameObject[] obstacles;


    [SerializeField] private float minDistFromPlayer;
   

    public void Generate()
    {
        // Get terrain dimensions
        float cornerX = terrain.bounds.size.x / 2;
        float cornerY = terrain.bounds.size.y / 2;
        float xPos = terrainTransform.position.x;
        float yPos = terrainTransform.position.y;

        /* Compute the number of obstacles corresponding to a particular 
           density. The current setting is 1% the terrain size in square units
           times the obstacle density setting.
        */
        int numberOfObstacles = (int) (terrain.bounds.size.x * 
            terrain.bounds.size.y * 0.01 * obstacleDensity);

        // Stores obstacle positions to avoid excessive overlap
        Vector2[] obstacleMap = new Vector2[numberOfObstacles];

        // Generates the obstacles
        for (int i = 0; i < numberOfObstacles; i++)
        {
            GameObject obstaclePrefab = obstacles[Random.Range(0, obstacles.Length)];
            GameObject newObstacle = Instantiate(obstaclePrefab,
                randomPos(minDistFromPlayer, i), Quaternion.identity);
            newObstacle.transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
        }

        // Attempts to find positions that avoid excessive overlap
        Vector2 randomPos(float minDistance, int i)
        {
            int limitCount = 0;
            Vector2 obstaclePos;
            do
            {
                obstaclePos = new Vector2(Random.Range(-cornerX + xPos, cornerX + xPos),
                Random.Range(-cornerY + yPos, cornerY + yPos));
                obstacleMap[i] = obstaclePos;
                limitCount++;
                // Code for debugging. Avoids infinite loops by giving up on
                // the mimimum distance requirements after 2000 attempts per obstacle
                if (limitCount > 20000) {
                    Debug.Log("Too many obstacles");
                    break;
                }

            }
            while (Vector2.Distance(obstaclePos, GameObject.Find("Player").transform.position) < minDistance
            || spaceUsed(obstaclePos, i));
            return obstaclePos;
        }

        // Finds whether or not a proposed position is too close to a used position
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
