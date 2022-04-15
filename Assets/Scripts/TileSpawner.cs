using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] tileTypes;
    [SerializeField] private Transform player;
    [SerializeField] private int tileSize;
    private Vector2 currentTilePos;
    private int tileCounter;
    private Vector2[] surroundingTilePos = new Vector2[7];
    private bool[] surroundingTileOccupancy = new bool[7];

    void Start()
    {
        GameObject startingTileType = tileTypes[0]; // Pick the first tile
        currentTilePos = new Vector2(0, 0);
        AddNewTile(startingTileType, currentTilePos);
    }

    void Update()
    {
        if (Vector2.Distance(currentTilePos, player.position) > tileSize / 2 - 10)
        {
            float angle = Mathf.Atan2(player.position.x - currentTilePos.x,
            player.position.y - currentTilePos.y);
            /* Check 8 positions surrounding the square (45 degrees apart).
               Position 0 begins at 22.5 degrees and ends at 67.5. ETC.
               This arrangement allows us to generate three new tiles when
               the player is near a corner, but only one new tile when it is
               far away from any corner.
            */
            for (int i = 0; i < 8; i++)
            {
                if (angle > Mathf.PI / 6 * i + 0.3926991f &&
                angle <= Mathf.PI / 6 * (i + 1) + 0.3926991f)
                {
                    if (surroundingTileOccupancy[i] == false)
                    {
                        GameObject startingTileType = tileTypes[0];

                        // If the position number is even, we are near a corner.
                        // Generate three tiles to be safe.
                        if ((i & 1) == 0)
                        {
                            surroundingTileOccupancy[(i - 1) % 8] = true;
                            surroundingTileOccupancy[i] = true;
                            surroundingTileOccupancy[i + 1] = true;
                            AddNewTile(startingTileType, tilePosSide((i - 1) % 8));
                            AddNewTile(startingTileType, tilePosCorner(i));
                            AddNewTile(startingTileType, tilePosSide(i + 1));
                        }
                        // If the position is odd, we are far from a corner.
                        // Generate one tile.
                        else
                        {
                            AddNewTile(startingTileType, tilePosSide(i));
                        }
                    }
                }
            }
        }
    }

    Vector2 tilePosSide(int i)
    {
        float ang = Mathf.PI / 4 + i * Mathf.PI / 4;
        return new Vector2(Mathf.Sin(ang) * tileSize,
           Mathf.Sin(ang) * tileSize);
    }

    Vector2 tilePosCorner(int i)
    {
        float ang = Mathf.PI / 4 + i * Mathf.PI / 4;
        return new Vector2(Mathf.Sin(ang) * tileSize * 1.41421356237f,
            Mathf.Sin(ang) * tileSize * 1.41421356237f);
    }

    void AddNewTile(GameObject tileType, Vector2 pos)
    {
        GameObject newTile = Instantiate(tileType, pos, Quaternion.identity);
        // Change tile size so that it is a tileSize * tileSize square.
        newTile.GetComponent<SpriteRenderer>().size =
            new Vector2(tileSize, tileSize);
        newTile.GetComponent<ObstacleGenerator>().Generate();
    }
}
