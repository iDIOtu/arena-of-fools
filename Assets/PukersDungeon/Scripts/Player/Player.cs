using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;
    [SerializeField] private PlayerCastScenesManager _scenesManager;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private WaveSpawner _spawner;

    private void OnEnable()
    {
        _health.Died += Die;
        _spawner.GameIsWon += Win;
    }

    private void Die()
    {
        _controller.Disable();
        _animator.SetDie();
        _scenesManager.PlayDeathCutscene();
    }

    private void Win()
    {
        _controller.Disable();
        _animator.SetWin();
        _scenesManager.PlayWinCutscene();
    }
}
