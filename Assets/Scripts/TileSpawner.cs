using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] tileTypes;
    [SerializeField] private Transform player;
    [SerializeField] private int blockSize;
    private Vector2 currentTilePos;
    private int tileCounter;
    private Vector2[] surroundingTilePos = new Vector2[7];

    void Start()
    {
        GameObject startingTileType = tileTypes[0]; // Pick the first tile
        currentTilePos = new Vector2(0, 0);
        AddNewTile(startingTileType, currentTilePos);
    }

    void Update()
    {
        if (Vector2.Distance(currentTilePos, player.position) > blockSize/2 - 10)
        {
            Debug.Log("Time to generate new tile");
        }
    }

    void AddNewTile(GameObject tileType, Vector2 pos)
    {
        GameObject newTile = Instantiate(tileType, pos, Quaternion.identity);

        // Change tile size so that it is a blockSize * blockSize square.
        newTile.GetComponent<SpriteRenderer>().size =
            new Vector2(blockSize, blockSize);
        newTile.GetComponent<ObstacleGenerator>().Generate();
    }
}
