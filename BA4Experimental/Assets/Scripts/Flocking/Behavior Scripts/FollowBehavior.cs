using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Follow")]
public class FollowBehavior : FilteredFlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbors, return no adjustment
        if (context.Count == 0)
        {
            return agent.transform.up;
        }

        //add all points together and average
        Vector2 followMove = Vector2.zero;
        int nAvoid = 0;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            if (Vector2.SqrMagnitude(item.position - agent.transform.position) < flock.SquareAvoidanceRadius)
            {
                nAvoid++;
                followMove += (Vector2)(agent.transform.position + item.position);
            }

        }

        if (nAvoid > 0)
        {
            followMove /= nAvoid;
        }
        return followMove;
    }
}

