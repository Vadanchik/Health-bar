using UnityEngine;
using UnityEngine.UI;

public class BarHealthViewer : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _healthBar;

    private void OnEnable()
    {
        _health.HealthChanged += BarView;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= BarView;
    }

    private void BarView(float value)
    {
        _healthBar.value = value / _health.MaxHealth;
    }
}
