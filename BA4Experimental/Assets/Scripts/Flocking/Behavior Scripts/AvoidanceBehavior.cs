using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")]
public class AvoidanceBehavior : FilteredFlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbors, return no adjustment
        if (context.Count == 0)
        {
            return agent.transform.up;
        }

        //add all points together and average
        Vector2 avoidanceMove = Vector2.zero;
        int nAvoid = 0;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            Vector2 closestPoint = item.gameObject.GetComponent<Collider2D>().ClosestPoint(agent.transform.position);

            if(Vector2.SqrMagnitude((Vector3)closestPoint - agent.transform.position) < flock.SquareAvoidanceRadius){
                nAvoid++;
                avoidanceMove += (Vector2)(agent.transform.position - (Vector3)closestPoint);
            }
   
        }

        if(nAvoid > 0)
        {
            avoidanceMove /= nAvoid;
        }
        return avoidanceMove;
    }
}
