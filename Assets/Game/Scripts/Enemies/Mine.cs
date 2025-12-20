using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _explosionRadius;
    [SerializeField] private int _activationRadius;
    [SerializeField] private int _duration;

    private bool _active;
    private float _time;

    private void Update()
    {
        if(!_active && OnMine())
        {
            Activate();
        }

        if(_active == false)
            return;
        
        _time += Time.deltaTime;

        if(_time >= _duration)
        {
            Explosion();

            Destroy(gameObject);
        }
    }

    private bool OnMine()
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

    private void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);
        
        foreach(Collider collider in colliders)
        {
            IDamageble damageble = collider.GetComponent<IDamageble>();

            if(damageble != null)
                damageble.TakeDamage(_damage);
        }
    }

    private void Activate() => _active = true;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, _explosionRadius);

        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawSphere(transform.position, _activationRadius);
    }
}
