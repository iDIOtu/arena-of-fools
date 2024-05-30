using UnityEngine.AI;
using UnityEngine;

public class Leg : Enemy
{
    private Animator _animator;
    private NavMeshAgent _agent;

    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        EnemyMovement();
        Attack();
    }

    protected override void EnemyMovement()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            _agent.SetDestination(_player.position);
        }
    }

    protected override void Attack()
    {
        float distance = Vector3.Distance(_animator.transform.position, _player.position);

        if (distance < _damageradius && _isAttacking)
        {
            _animator.SetTrigger("Attack");
            StartCoroutine(AttacDelay());
        }
    }

    protected override void Die()
    {
        enabled = false;
        _animator.SetTrigger("Death");
        Destroy(gameObject, 3.0f);
    }
}