using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandscapeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] landscapes;
    public int blockSize;

    void Start()
    {
        GameObject startingLandscape = landscapes[0]; // Pick the first landscape
        
        GameObject newLandscape = Instantiate(startingLandscape,
                new Vector2(0, 0), Quaternion.identity);

        // Change landscape size so that it is a blockSize * blockSize square.
        newLandscape.GetComponent<SpriteRenderer>().size = new Vector2(blockSize, blockSize);
        newLandscape.GetComponent<ObstacleGenerator>().Generate();
        
    }

    
    void Update()
    {
        
    }
}
