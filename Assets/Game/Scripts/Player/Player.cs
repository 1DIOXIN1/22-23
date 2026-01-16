using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour, IDamageble, IHealable, IDirectionMovable, IDirectionRotator, IDirectionJumper
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private int _maxHealth;
    [SerializeField] private AnimationCurve _jumpCurve;
    
    private NavMeshAgent _agent;
    private NavMeshAgentMover _mover;
    private DirectionRotator _rotator;
    private NavMeshAgentJumper _jumper;
    private Health _health;

    public int CurrentHealth => _health.CurrentHealth;
    public int MaxHealth => _health.MaxHealth;
    public Vector3 CurrentVelocity => _mover.CurrentVelocity;
    public Quaternion CurrentRotation => _rotator.CurrentRotation;
    public bool InJumpProcess => _jumper.InProcess;
    public Vector3 TargetPosition => _mover.CurrentTarget;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

        _health = new Health(_maxHealth);
        _mover = new NavMeshAgentMover(_agent);
        _rotator = new DirectionRotator(transform, _rotationSpeed);
        _jumper = new NavMeshAgentJumper(_agent.speed, _agent, _jumpCurve, this);
    }

    private void Update()
    {
        _mover.Update();
        _rotator.Update(Time.deltaTime);
    }

    public bool IsOnNavMeshLink(out OffMeshLinkData offMeshLinkData)
    {
        if(_agent.isOnOffMeshLink)
        {
            offMeshLinkData = _agent.currentOffMeshLinkData;
            return true;
        }

        offMeshLinkData = default(OffMeshLinkData);
        return false;
    }

    public void SetMoveDirection(Vector3 direction) => _mover.SetMoveDirection(direction);
    public void SetRotationDirection(Vector3 direction) => _rotator.SetRotationDirection(direction);
    public void Jump(OffMeshLinkData offMeshLinkData) => _jumper.Jump(offMeshLinkData);

    public void Heal(int value) => _health.Heal(value);
    public void TakeDamage(int value) => _health.TakeDamage(value);
    public bool IsDead() => _health.IsDead;
}
