using UnityEngine;

public class HealthKit : MonoBehaviour
{
    [SerializeField] private int _healPoints;

    private void OnTriggerEnter(Collider other)
    {
        IDamageble damageble = other.GetComponent<IDamageble>();

        if(damageble != null)
        {
            damageble.Heal(_healPoints);

            Destroy(gameObject);
        }  
    }
}
