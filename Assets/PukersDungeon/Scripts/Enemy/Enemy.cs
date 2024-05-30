using UnityEngine;
using System.Collections;
using System;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] public float _damageradius;
    [SerializeField] public float _damage;
    [SerializeField] public float _attackDelay;
    [SerializeField] public float _maxHealth;

    protected Transform _player;

    protected bool _isAttacking = true;
    private float _currentHealth;

    public static event Action EnemyDied;

    protected virtual void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
    }

    protected abstract void EnemyMovement();

    protected abstract void Attack();

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth == 0)
        {
            Die();
            EnemyDied?.Invoke();
        }
    }

    protected abstract void Die();

    public void Damage()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _damageradius);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out PlayerHealth player))
            {
                player.TakeDamage(_damage);
            }
        }
    }

    protected virtual IEnumerator AttacDelay()
    {
        _isAttacking = false;
        yield return new WaitForSeconds(_attackDelay);
        _isAttacking = true;
    }
}