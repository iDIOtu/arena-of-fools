using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;
    [SerializeField] private PlayerCastScenesManager _scenesManager;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private PlayerHealth _health;

    private void OnEnable()
    {
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
    }

    private void Die()
    {
        _controller.Disable();
        _animator.SetDie();
        _scenesManager.PlayDeathCutscene();
    }
}
