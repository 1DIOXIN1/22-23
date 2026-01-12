using UnityEngine;

public class MineView : MonoBehaviour
{
    [SerializeField] private Mine _mine;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _explosionSound;

    private bool _isExploded = false;

    private void Update()
    {
        if(_mine == null && _isExploded == false)
        {
            _audioSource.PlayOneShot(_explosionSound);
            _isExploded = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(_isExploded)
            return;
            
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, _mine.ExplosionRadius);

        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawSphere(transform.position, _mine.ActivationRadius);
    }
}
