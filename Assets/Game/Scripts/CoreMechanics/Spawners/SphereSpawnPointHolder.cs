using UnityEngine;

public class SphereSpawnPointHolder : ISpawnPointHolder
{
    [SerializeField] private float _radius;
    [SerializeField] private Transform _center;

    public SphereSpawnPointHolder(Transform center, float radius)
    {
        _center = center;
        _radius = radius;
    }
    
    public Vector3 GetSpawnPoint() => _center.position + Random.onUnitSphere * _radius;
}
