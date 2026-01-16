using UnityEngine;

public class HealthKit : MonoBehaviour
{
    [SerializeField] private int _healPoints;

    private void OnTriggerEnter(Collider other)
    {
        IHealable damageble = other.GetComponent<IHealable>();

        if(damageble != null)
        {
            damageble.Heal(_healPoints);

            Destroy(gameObject);
        }  
    }
}
