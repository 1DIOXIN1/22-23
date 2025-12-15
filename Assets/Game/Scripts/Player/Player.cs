using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private int _maxHealth;
    
    private NavMeshAgent _agent;
    private Vector3 _targetPosition;
    private Camera _camera;
    private Mover _mover;
    private Health _health;

    public int CurrentHealth => _health.CurrentHealth;
    public int MaxHealth => _health.MaxHealth;
    public Vector3 CurrentVelocity => _agent.velocity;
    public Vector3 TargetPosition => _targetPosition;

    private void Awake()
    {
        _camera = Camera.main;
        _agent = GetComponent<NavMeshAgent>();

        _health = new Health(_maxHealth);
        _mover = new NavMeshAgentMover(_agent, transform, _moveSpeed, _rotationSpeed);
    }

    private void Update()
    {
        if(IsDead() == false && Input.GetKeyDown(KeyCode.Mouse0) && TryGetTargetPoint(Input.mousePosition, out _targetPosition))
        {
            _mover.ProcessMoveTo(_targetPosition, Time.deltaTime);
            _mover.ProcessRotateTo(_targetPosition, Time.deltaTime);
        }
    }

    public void TakeDamage(int damage) => _health.TakeDamage(damage);
    public bool IsDead() => _health.IsDead;

    private bool TryGetTargetPoint(Vector3 cursorPosition, out Vector3 targetPoint)
    {
        targetPoint = Vector3.zero;
        Ray ray = _camera.ScreenPointToRay(cursorPosition);

        if(Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            targetPoint = hitInfo.point;
            return true;
        }

        return false;     
    }
}
