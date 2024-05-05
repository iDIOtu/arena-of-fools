using UnityEngine;
using UnityEngine.AI;

public class Legbehaviour : MonoBehaviour
{
    [SerializeField] private float attackRange;

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
        _agent.SetDestination(_player.position);
        float distance = Vector3.Distance(_animator.transform.position, _player.position);

        if (distance < attackRange)
        {
            _animator.SetBool("isAttacking", true);
        }

        if (distance > attackRange+10)
        {
            _animator.SetBool("isAttacking", false);
        }
    }
}