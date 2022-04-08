using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingManager : MonoBehaviour
{
    [SerializeField] public FlockAgent flockUnit;
    [SerializeField] public int numUnits;
    public GameObject[] allUnits;
    public Vector2 flockLimits = new Vector2(5, 5);

    const float flockDensity = 0.08f;
    public float driveFactor = 10f;
    public float neighborRadius = 0.5f;
    public float avoidanceRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighborRadius;
    public float SquareAvoidanceRadius { get { return SquareAvoidanceRadius; } }
    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = squareMaxSpeed * squareMaxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        SquareAvoidanceRadiusRadius = squareNeighborRadius * avoidanceRadiusMultiplier;

        for (int i = 0; i < numUnits; i++)
        {
            Instantiate(
                flockUnit,
                Random.insideUnitCircle * startingCount * flockDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f),
                transform);
            newAgent.name = "flockUnit " + i;
            agents.
        }

        // allUnits = new GameObject[numUnits];
        // for(int i = 0; i < numUnits; i++)
        // {
        //     Vector2 pos = this.transform.position + new Vector2(Random.Range(0, 5),
        //                                                 Vector2(Random.Range(0, 5)));
        //     allUnits[i] = (GameObject) Instantiate(flockUnit, pos, Quaternion.identity);
                                                        
        // }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
