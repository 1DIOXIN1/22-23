using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentMover : Mover
{
    private NavMeshAgent _agent;

    public NavMeshAgentMover(NavMeshAgent agent, Transform charachterTransform, float moveSpeed, float rotationSpeed) : base(charachterTransform, moveSpeed, rotationSpeed)
    {
        _agent = agent;
        _agent.speed = moveSpeed;
        _agent.angularSpeed = rotationSpeed;
    }

    public override void ProcessMoveTo(Vector3 target, float deltaTime)
    {
        _agent.SetDestination(target);
    }
}
