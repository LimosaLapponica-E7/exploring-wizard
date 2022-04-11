using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlockBehavior : MonoBehaviour
{

    public abstract Vector2 CalculateMove(FlockAgent agent, List<Transform> context, FlockingManager flock);
 
}
