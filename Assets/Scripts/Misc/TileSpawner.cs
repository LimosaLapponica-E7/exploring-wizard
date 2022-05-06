using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] tileTypes;
    [SerializeField] private Transform player;
    [Range(25, 50)] public float tileSize;
    private Vector2 currentTilePos;
    private int tileCounter;
    private Vector2[] surroundingTilePos = new Vector2[8];
    private List<Vector2> populatedTilePos = new List<Vector2>();

    void Start()
    {
        currentTilePos = new Vector2(0, 0);
        AddNewTile(currentTilePos);
    }

    void Update()
    {
        // Run these computations every 15 frames
        if (Time.frameCount % 15 == 0 && player != null)
        {
            if (Vector2.Distance(currentTilePos, player.position) > tileSize / 2 - 12)
            {
                Vector2 playerPosition = player.position;
                currentTilePos = getCurrentTile(playerPosition);
                float angle = Mathf.Atan2(playerPosition.y - currentTilePos.y,
                playerPosition.x - currentTilePos.x);
                if (angle < 0) angle += 2 * Mathf.PI; // Deal with positive angles

                /* Check 8 positions surrounding the square (45 degrees apart).
                   Position 0 begins at 22.5 degrees and ends at 67.5. ETC.
                   This arrangement allows us to generate three new tiles when
                   the player is near a corner, but only one new tile when it is
                   far away from any corner.
                */
                for (int i = 0; i < 8; i++)
                {
                    if (angle > Mathf.PI / 4 * i + 0.3926991f &&
                        angle <= Mathf.PI / 4 * (i + 1) + 0.3926991f)
                    {
                        /* If the position number is even, we are near a corner.
                           Generate three tiles to be safe:
                           One at the corner, and one on each side of the corner. */
                        if ((i & 1) == 0)
                        {
                            // If not yet generated, add tile behind (counterclockwise) the corner tile 
                            if (tileIsFree(tilePosSide(mod((i - 1), 8))))
                                AddNewTile(tilePosSide(mod((i - 1), 8)));

                            // If not yet generated, add corner tile
                            if (tileIsFree(tilePosCorner(i)))
                                AddNewTile(tilePosCorner(i));

                            // If not yet generated, add tile in front (counterclockwise) the corner tile
                            if (tileIsFree(tilePosSide(i + 1)))
                                AddNewTile(tilePosSide(i + 1));
                        }
                        // If the position is odd, we are far from a corner.
                        // Generate one tile in front of the player.
                        else
                        {
                            if (tileIsFree(tilePosSide(i)))
                            {
                                AddNewTile(tilePosSide(i));
                            }

                        }
                    }
                }
            }
        }

        // Destroy old landscapes every 600 frames
        if (Time.frameCount % 600 == 0)
            destroyDistantObjects();
    }

    void destroyDistantObjects()
    {
        for (int i = 0; i < populatedTilePos.Count; i++)
        {
            if ((Vector2.Distance(populatedTilePos[i], player.position)) > tileSize)
            {
                destroyObjects(populatedTilePos[i]);
                populatedTilePos.RemoveAt(i);
            }
        }
    }

    // Adapted from http://answers.unity.com/answers/1155767/view.html
    void destroyObjects(Vector2 blastZone)
    {
        // Get an array containing the colliders of objects in a region
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(blastZone, new Vector2(tileSize, tileSize), 0f);

        // Destroy each item in the array
        for (int i = 0; i < hitColliders.Length; i++)
            Destroy(hitColliders[i].gameObject);
    }

    Vector2 getCurrentTile(Vector2 playerPos)
    {
        float minDistance = tileSize;
        int tileIndex = 0;
        for (int i = 0; i < populatedTilePos.Count; i++)
        {
            float distance = Vector2.Distance(populatedTilePos[i], playerPos);
            if (distance < minDistance)
            {
                minDistance = distance;
                tileIndex = i;
            }
        }
        return populatedTilePos[tileIndex];
    }

    bool tileIsFree(Vector2 pos)
    {
        foreach (Vector2 tilePos in populatedTilePos)
        {
            if (tilePos == pos)
                return false;
        }
        return true;
    }

    int mod(float x, float y)
    {
        return (int)(x - y * Mathf.Floor(x / y));
    }

    Vector2 tilePosSide(int i)
    {
        float ang = Mathf.PI / 4 + i * Mathf.PI / 4;
        return new Vector2(Mathf.Round(Mathf.Cos(ang) * tileSize), Mathf.Round(Mathf.Sin(ang) * tileSize))
        + currentTilePos;
    }

    Vector2 tilePosCorner(int i)
    {
        float ang = Mathf.PI / 4 + i * Mathf.PI / 4;
        return new Vector2(Mathf.Round(Mathf.Cos(ang) * tileSize * 1.41421356237f),
            Mathf.Round(Mathf.Sin(ang) * tileSize * 1.41421356237f)) + currentTilePos;
    }

    void AddNewTile(Vector2 pos)
    {
        int landscapeIndex = PlayerStats.instance.playerLevel % tileTypes.Length;
        GameObject tileType = tileTypes[landscapeIndex];
        GameObject newTile = Instantiate(tileType, pos, Quaternion.identity);
        // Change tile size so that it is a tileSize * tileSize square.
        newTile.GetComponent<SpriteRenderer>().size = new Vector2(tileSize, tileSize);

        /* The collider is used for finding old tiles to destroy. 
           It is smaller than the tile itself because the destruction system searches an area with 
           boxed in tileSize and we only want to destroy one tile at a time */
        newTile.GetComponent<BoxCollider2D>().size = new Vector2(tileSize * 0.8f, tileSize * 0.8f);
        newTile.GetComponent<ObstacleGenerator>().Generate();

        // Add tile center position to list of populated tiles
        populatedTilePos.Add(pos);
    }
}
