using UnityEngine;

public class TopDownController : Controller
{
    private Vector3 _targetPosition;
    private IDirectionMovable _movable;
    private IDirectionRotator _rotator;
    private Camera _camera;

    public TopDownController(IDirectionMovable movable, IDirectionRotator rotator, Camera camera)
    {
        _movable = movable;
        _rotator = rotator;
        _camera = camera;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && TryGetTargetPoint(Input.mousePosition, out _targetPosition))
        {
            _movable.SetMoveDirection(_targetPosition);
            _rotator.SetRotationDirection(_targetPosition);
        }  
    }

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
