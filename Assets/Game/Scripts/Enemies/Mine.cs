using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _explosionDistance;
    [SerializeField] private int _mineRadius;
    [SerializeField] private int _duration;
    [SerializeField] private Player _player;
    
    private bool _active;
    private float _time;
    private DistanceDetector _distanceDetrector;

    private void Start()
    {
        _distanceDetrector = new DistanceDetector(transform, _player.transform);
    }

    private void Update()
    {
        if(OnMine())
        {
            Activate();
        }

        if(_active == false)
            return;
        
        _time += Time.deltaTime;

        if(_time >= _duration)
        {
            if(InRadiusExplosion())
                _player.TakeDamage(_damage);

            Destroy(gameObject);
        }
    }

    private bool OnMine() => _distanceDetrector.InZone(_mineRadius);
    private bool InRadiusExplosion() => _distanceDetrector.InZone(_explosionDistance);

    private void Activate() => _active = true;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(255, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, _explosionDistance);

        Gizmos.color = new Color(0, 0, 255, 0.5f);
        Gizmos.DrawSphere(transform.position, _mineRadius);
    }
}
