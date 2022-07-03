using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Follow Radius")]
public class FollowRadiusBehavior : FlockBehavior
{
    Flock flock;

    Vector2 center;
    public float radius = 15f;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        center = flock.player.transform.position + new Vector3(-4f,0);

        Vector2 centerOffset = center - (Vector2)agent.transform.position;
        float t = centerOffset.magnitude / radius;
        if (t < 0.7f)
        {
            return Vector2.zero;
        }

        return centerOffset * t * t;
    }
}
