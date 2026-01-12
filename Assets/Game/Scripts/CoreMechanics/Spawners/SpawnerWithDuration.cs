using System.Collections;
using UnityEngine;

public abstract class SpawnerWithDuration : MonoBehaviour
{
    protected Transform _center;

    [SerializeField] protected float _duration;
    [SerializeField] protected float _radius;
    [SerializeField] private GameObject _prafabSpawnObject;

    private Coroutine _spawnProcess;
    
    public virtual void Initialization(Transform center)
    {
        _center = center;

        TurnOn();
    }
    
    public bool IsActive => _spawnProcess != null;

    public void TurnOn()
    {
        _spawnProcess = StartCoroutine(Spawn());
    }
    
    public void TurnOff()
    {
        StopCoroutine(_spawnProcess);
        _spawnProcess = null;
    }

    protected abstract Vector3 GetPoint();

    private IEnumerator Spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(_duration);
            
            Instantiate(_prafabSpawnObject, GetPoint(), Quaternion.identity);
        }
    }
}
