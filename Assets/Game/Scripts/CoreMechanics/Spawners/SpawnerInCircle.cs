using UnityEngine;

public class SpawnerInCircle : SpawnerWithDuration
{
    protected override Vector3 GetPoint()
    {
        Vector3 randomCirclePoint = new Vector3(Random.insideUnitCircle.x, 0, Random.insideUnitCircle.y);

        return _center.position + randomCirclePoint * _radius;
    }
}
