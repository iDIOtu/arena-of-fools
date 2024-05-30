using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;

    public event Action<float> HealthChanged;
    public event Action Died;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
        HealthChanged?.Invoke(_currentHealth / 100.0f);

        if (_currentHealth == 0)
        {
            Died?.Invoke();
        }
    }
}
