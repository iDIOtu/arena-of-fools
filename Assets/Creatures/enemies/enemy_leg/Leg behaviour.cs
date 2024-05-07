using System.Collections;
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

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {   
        float distance = Vector3.Distance(_animator.transform.position, _player.position);

        if (distance < _attackRange)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _damageradius);
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out MainCharacterController player))
                {
                    _animator.SetBool("isAttacking", true);
                    player.GetDamage(_damage);
                }
            }
        }
        else
        {
            _animator.SetBool("isAttacking", false);
        }

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            _agent.SetDestination(_player.position);
        }
    }
}