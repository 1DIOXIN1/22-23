using System.Collections;
using UnityEngine;

public class SpawnerWithDuration : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private GameObject _prafabSpawnObject;
    private ISpawnPointHolder _spawnPointHolder;

    private Coroutine _spawnProcess;
    
    public void Initialization(ISpawnPointHolder spawnPointHolder)
    {
        _spawnPointHolder = spawnPointHolder;

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


    private IEnumerator Spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(_duration);
            
            Instantiate(_prafabSpawnObject, _spawnPointHolder.GetSpawnPoint(), Quaternion.identity);
        }
    }
}
