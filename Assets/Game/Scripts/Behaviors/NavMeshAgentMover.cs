using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentMover
{
    private NavMeshAgent _agent;
    private Vector3 _target;

    public NavMeshAgentMover(NavMeshAgent agent)
    {
        _target = agent.transform.position;
        _agent = agent;
    }

    public Vector3 CurrentVelocity => _agent.velocity;
    public Vector3 CurrentTarget => _target;

    public void Update()
    {
        _agent.SetDestination(_target);
    }

    public void SetMoveDirection(Vector3 target) => _target = target;
}
