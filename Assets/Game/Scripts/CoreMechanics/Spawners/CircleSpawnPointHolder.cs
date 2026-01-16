using UnityEngine;

public class CircleSpawnPointHolder : ISpawnPointHolder
{
    [SerializeField] private float _radius;
    [SerializeField] private Transform _center;

    public CircleSpawnPointHolder(Transform center, float radius)
    {
        _center = center;
        _radius = radius;
    }

    public Vector3 GetSpawnPoint()
    {
        Vector3 randomCirclePoint = new Vector3(Random.insideUnitCircle.x, 0, Random.insideUnitCircle.y);

        return _center.position + randomCirclePoint * _radius;
    }
}
