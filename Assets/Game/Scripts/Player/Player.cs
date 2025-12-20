using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour, IDamageble, IDirectionMovable, IDirectionRotator
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private int _maxHealth;
    
    private NavMeshAgent _agent;
    private NavMeshAgentMover _mover;
    private DirectionRotator _rotator;
    private Health _health;

    public int CurrentHealth => _health.CurrentHealth;
    public int MaxHealth => _health.MaxHealth;
    public Vector3 CurrentVelocity => _mover.CurrentVelocity;
    public Quaternion CurrentRotation => _rotator.CurrentRotation;
    public Vector3 TargetPosition => _mover.CurrentTarget;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

        _health = new Health(_maxHealth);
        _mover = new NavMeshAgentMover(_agent);
        _rotator = new DirectionRotator(transform, _rotationSpeed);
    }

    private void Update()
    {
        _mover.Update();
        _rotator.Update(Time.deltaTime);
    }

    public void SetMoveDirection(Vector3 direction) => _mover.SetMoveDirection(direction);
    public void SetRotationDirection(Vector3 direction) => _rotator.SetRotationDirection(direction);

    public void TakeDamage(int value) => _health.TakeDamage(value);
    public bool IsDead() => _health.IsDead;
}
