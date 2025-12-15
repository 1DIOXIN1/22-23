using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _markerPrefab;

    private readonly int _velocityHash = Animator.StringToHash("Velocity");
    private readonly int _isDeadHash = Animator.StringToHash("IsDead");

    private float _perecentInjuredLine = 0.3f;
    private GameObject _CurrentMarker;

    private void Update()
    {
        if(_player.IsDead())
        {
            _animator.SetTrigger(_isDeadHash);
            return;
        }

        if(_player.CurrentHealth / _player.MaxHealth <= _perecentInjuredLine)
            _animator.SetLayerWeight(1, 1);
        else
            _animator.SetLayerWeight(0, 1);

        _animator.SetFloat(_velocityHash, _player.CurrentVelocity.magnitude);

        MarkerLogic();
    }

    private void MarkerLogic()
    {
        if( _player.CurrentVelocity.magnitude >= 0.05f)
        {
            if(_CurrentMarker == null)
                _CurrentMarker = Instantiate(_markerPrefab,  _player.TargetPosition, Quaternion.identity);
            else
                _CurrentMarker.transform.position = _player.TargetPosition;
        }
        else
        {
            Destroy(_CurrentMarker);
        }
    }
}
