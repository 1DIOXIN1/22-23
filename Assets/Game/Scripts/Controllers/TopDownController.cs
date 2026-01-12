using UnityEngine;
using UnityEngine.AI;

public class TopDownController : Controller
{
    private Vector3 _targetPosition;
    private IDirectionMovable _movable;
    private IDirectionRotator _rotator;
    private IDirectionJumper _jumper;
    private SpawnerWithDuration _spawner;
    private Camera _camera;

    public TopDownController(IDirectionMovable movable, IDirectionRotator rotator, IDirectionJumper jumper, SpawnerWithDuration spawner, Camera camera)
    {
        _movable = movable;
        _rotator = rotator;
        _jumper = jumper;
        _spawner = spawner;
        _camera = camera;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(_spawner.IsActive)
            {
                _spawner.TurnOff();
                Debug.Log("Спавнер отключён");
            }  
            else
            {
                _spawner.TurnOn();
                Debug.Log("Спавнер включён");
            }
        }

        if(_jumper.IsOnNavMeshLink(out OffMeshLinkData offMeshLinkData))
        {
            if(_jumper.InJumpProcess == false)
            {
                _rotator.SetRotationDirection(offMeshLinkData.endPos);

                _jumper.Jump(offMeshLinkData);
            }

            return;
        }

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
