using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private Image _heathBar;
    [SerializeField] private float _healthDecreaseDuration;

    private void OnEnable()
    {
        _health.HealthChanged += TakeDamage;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= TakeDamage;
    }

    private void TakeDamage(float currentHealth)
    {
        StartCoroutine(DecreaseInHealth(currentHealth));
    }

    private IEnumerator DecreaseInHealth(float currentHealth)
    {
        float elapsedTime = 0.0f;
        float previousHealth = _heathBar.fillAmount;

        while (elapsedTime < _healthDecreaseDuration)
        {
            elapsedTime += Time.deltaTime;
            float timePosition = elapsedTime / _healthDecreaseDuration;
            float intermediateHealth = Mathf.Lerp(previousHealth, currentHealth, timePosition);
            _heathBar.fillAmount = intermediateHealth;

            yield return null;
        }
    }
}