using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingManager : MonoBehaviour
{
    [SerializeField] public FlockAgent flockUnit;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehavior behavior;

    [Range(3, 250)]
    public int numUnits = 10;

    const float flockDensity = 0.08f;
    [Range(1f,100f)]
    public float driveFactor = 10f;

    [Range(1f, 100f)]
    public float maxSpeed = 5f;

    [Range(0f, 10f)]
    public float neighborRadius = 1.5f;

    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    

    float squareMaxSpeed;
    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }
    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for (int i = 0; i < numUnits; i++)
        {
           FlockAgent newAgent = Instantiate(
                flockUnit,
                Random.insideUnitCircle * numUnits * flockDensity +  
                    new Vector2(transform.position.x, transform.position.y),
                    Quaternion.Euler(Vector3.forward * Random.Range(0f,360f)),
                    transform);
            newAgent.name = "flockUnit " + i;
            agents.Add(newAgent);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < agents.Count; i++)
        {
            FlockAgent agent = agents[i];
            if(agent != null)
            {
                List<Transform> context = GetNearbyObjects(agent);

                Vector2 move = behavior.CalculateMove(agent, context, this);
                move *= driveFactor;
                if (move.sqrMagnitude > squareMaxSpeed)
                {
                    move = move.normalized * maxSpeed;
                }
                agent.Move(move);
            }
            else
            {
                agents.RemoveAt(i);
                i--;
            }
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
