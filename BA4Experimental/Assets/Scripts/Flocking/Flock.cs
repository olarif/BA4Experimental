using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    private GameObject player;
    public float aggroDistance = 5f;

    public FlockAgent agentPrefab;
    [HideInInspector] public List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehavior behavior;

    [Range(1, 500)]
    public int startingCount = 250;
    const float agentDensity = 0.08f;
    [Range(0f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;

    [Range(1f, 10f)]
    public float neighborRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    public Transform spawn;

    float squareMaxSpeed;
    float squareNeighborRadius;
    float squareAvoidanceRadius;

    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for(int i = 0; i < startingCount; i++)
        {
            FlockAgent newAgent = Instantiate(
                    agentPrefab,
                    (Vector2)spawn.position + Random.insideUnitCircle * startingCount * agentDensity,
                    //spawn.position ,
                    Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                    transform
                );
            newAgent.name = "Agent " + i;
            newAgent.Initialize(this);
            agents.Add(newAgent);
        }
    }

    void Update()
    {
        foreach(FlockAgent agent in agents.ToArray())
        {
            List<Transform> context = GetNearbyObjects(agent);

            Vector2 move = behavior.CalculateMove(agent, context, this);
            move *= driveFactor;
            if(move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);


            //check is distance to player is small -> remove agent from list 
            float distance = Vector2.Distance(agent.transform.position, player.transform.position);

            if(distance < aggroDistance)
            {
                agents.Remove(agent);
            }

            //Debug.Log(agent + " " + distance);
        }
    }

    List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);

        foreach(Collider2D c in contextColliders){
            if (c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }

        return context;
    }

    public void RemoveFromList(FlockAgent agent)
    {
        agents.Remove(agent);
    }
}
