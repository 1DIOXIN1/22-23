using UnityEngine;

public class SpawnerInSphere : SpawnerWithDuration
{
    protected override Vector3 GetPoint() => _center.position + Random.onUnitSphere * _radius;
}
