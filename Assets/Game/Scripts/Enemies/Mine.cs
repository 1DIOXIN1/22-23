using System.Collections;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _explosionRadius;
    [SerializeField] private int _activationRadius;
    [SerializeField] private int _duration;
    
    private Coroutine _explosionProcess;

    private bool _active => _explosionProcess != null;
    
    public int ExplosionRadius => _explosionRadius;
    public int ActivationRadius => _activationRadius;

    private void Update()
    {
        if(IsAnyDamagableInRange())
        {
           if(_active == false)
            {
                _explosionProcess = StartCoroutine(ExplosionWithDuration());
            }
        }
    }

    private bool IsAnyDamagableInRange()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _activationRadius);

        foreach(Collider collider in colliders)
        {
            IDamageble damageble = collider.GetComponent<IDamageble>();

            if(damageble != null)
                return true;
        }

        return false;
    }

    private IEnumerator ExplosionWithDuration()
    {
        yield return new WaitForSeconds(_duration) ;

        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);
        
        foreach(Collider collider in colliders)
        {
            IDamageble damageble = collider.GetComponent<IDamageble>();

            if(damageble != null)
                damageble.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}
