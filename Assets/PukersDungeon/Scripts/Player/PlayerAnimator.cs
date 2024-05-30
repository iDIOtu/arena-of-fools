using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void SetRun(bool isMove)
    {
        _animator.SetBool("Run", isMove);
    }

    public void SetJump()
    {
        _animator.SetTrigger("Jump");
    }

    public void SetAttack()
    {
        _animator.SetTrigger("Attack");
    }

    public void SetDie()
    {
        _animator.SetTrigger("Die");
    }

    public void SetWin()
    {
        _animator.SetTrigger("Win");
    }
}
