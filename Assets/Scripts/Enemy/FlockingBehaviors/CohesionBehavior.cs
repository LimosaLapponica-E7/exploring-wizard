using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Cohesion")]
public class CohesionBehavior : FlockBehavior
{

    Vector2 currentVelocity;
    public float agentSmoothTime = 0.5f;

    //find the middle point between all our neighbors, then try to move there
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, FlockingManager flock)
    {
        //if no neighbors, don't change anything
        if (context.Count == 0)
            return Vector2.zero;

        //add all points together and average
        Vector2 cohesionMove = Vector2.zero;
        foreach (Transform item in context)
        {
            cohesionMove += (Vector2)item.position;
        }
        cohesionMove /= context.Count;

        //create offset from agent transform
        cohesionMove -= (Vector2)agent.transform.position;
        cohesionMove = Vector2.SmoothDamp(agent.transform.up, cohesionMove, ref currentVelocity, agentSmoothTime);
        return cohesionMove;
    }

    
}
