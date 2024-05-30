using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private float _damageRadius;
    [SerializeField] private float _damage;
    public void DealingDamage—lose()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _damageRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(_damage);
            }
        }
    }
}
