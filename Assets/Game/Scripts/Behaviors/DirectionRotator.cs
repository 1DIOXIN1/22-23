using UnityEngine;

public class DirectionRotator
{
    private Transform _charachterTransform;
    private Vector3 _direction;

    public DirectionRotator(Transform charachterTransform, float speed)
    {
        RotationSpeed = speed;
        _charachterTransform = charachterTransform;
    }

    public float RotationSpeed{get; private set;}

    public Quaternion CurrentRotation => _charachterTransform.rotation;

    public void Update(float deltaTime)
    {
        if(_direction == Vector3.zero)//Возможно костыль
            return;

        Quaternion lookRotation = Quaternion.LookRotation(_direction);
        float step = RotationSpeed * deltaTime;

        _charachterTransform.rotation = Quaternion.RotateTowards(_charachterTransform.rotation, lookRotation, step);
    }

    public void SetRotationDirection(Vector3 direction) => _direction = direction - _charachterTransform.position;
}
