using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Legbehaviour : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] private float _damageradius;
    [SerializeField] private float _damage;

    private Animator _animator;
    private NavMeshAgent _agent;
    private Transform _player;
    private float _healthPoints = 9.0f;
    private bool isAttacking = true;
    private bool isDeath = true;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {   
        float distance = Vector3.Distance(_animator.transform.position, _player.position);

        if (distance < _attackRange &&  isAttacking)
        {
            _animator.SetTrigger("isAttacking");
            StartCoroutine(AttackWithDelay());
        }

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            _agent.SetDestination(_player.position);
        }
    }

    public void GetDamage(float damage)
    {
        _healthPoints -= damage;

        if (_healthPoints <= 0 && isDeath)
        {
            _animator.SetTrigger("isDeath");
            StartCoroutine(DestroyAfterDelay());
        }
    }


    private IEnumerator DestroyAfterDelay()
    {
        isDeath = false;
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }

    private void Attack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _damageradius);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out MainCharacterController player))
            {
                player.GetDamage(_damage);
            }
        }
    }

    private IEnumerator AttackWithDelay()
    {
        isAttacking = false;
        yield return new WaitForSeconds(1.0f);
        isAttacking = true;
    }
}