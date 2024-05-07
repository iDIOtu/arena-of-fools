using UnityEngine;
using UnityEngine.UI;

public class HealthСontrol : MonoBehaviour
{
    public Image _heathBar;

    public void SetHealth(float damage)
    {
        _heathBar.fillAmount -= (damage / 100.0f) * Time.deltaTime;
    }
}