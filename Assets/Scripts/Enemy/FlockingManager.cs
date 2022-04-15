/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingManager : MonoBehaviour
{
    [SerializeField] public FlockAgent flockUnit;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehavior behavior;

    [Range(3, 250)]
    public int numUnits = 10;

    public Vector2 flockLimits = new Vector2(5, 5);



    const float flockDensity = 0.08f;
    [Range(1f,100f)]
    public float driveFactor = 10f;

    [Range(1f, 100f)]
    public float maxSpeed = 5f;

    [Range(1f, 10f)]
    public float neighborRadius = 0.5f;

    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    

    float squareMaxSpeed;
    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }
    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = squareMaxSpeed * squareMaxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for (int i = 0; i < numUnits; i++)
        {
           FlockAgent newAgent = Instantiate(
                flockUnit,
                Random.insideUnitCircle * numUnits * flockDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform);
            newAgent.name = "flockUnit " + i;
            agents.Add(newAgent);
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
        foreach (FlockAgent agent in agents)
        {
            
            List<Transform> context = GetNearbyObjects(agent);
            /*
            Vector2 move = behavior.CalculateMove(agent, context, this);
            move *= driveFactor;
            if(move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * squareMaxSpeed;
            }
            agent.Move(move);
            *//*
        } 
    }

    List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);
        foreach(Collider2D c in contextColliders)
        {
            if (c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }

        }
        return context;
    }
}
*/