using UnityEngine;

public interface IDirectionRotator
{
    Quaternion CurrentRotation{get;}
    void SetRotationDirection(Vector3 direction);
}
