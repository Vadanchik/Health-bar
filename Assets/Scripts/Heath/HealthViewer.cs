using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewer : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Slider _healthSmoothBar;

    [SerializeField] private float _smoothSpeed = 1.0f;

    private float _targetValue;

    private void OnEnable()
    {
        _health.HealthChanged += SetTargetValue;
        _health.HealthChanged += TextView;
        _health.HealthChanged += BarView;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= SetTargetValue;
        _health.HealthChanged -= TextView;
        _health.HealthChanged -= BarView;
    }

    private void Update()
    {
        SmoothBarView();
    }

    private void SetTargetValue(float value)
    {
        _targetValue = value;
    }

    private void TextView(float value)
    {
        _healthText.text = value.ToString() + "/" + _health.MaxHealth;
    }

    private void BarView(float value)
    {
        _healthBar.value = value / _health.MaxHealth;
    }

    private void SmoothBarView()
    {
        _healthSmoothBar.value = Mathf.MoveTowards(_healthSmoothBar.value, _targetValue / _health.MaxHealth, Time.deltaTime * _smoothSpeed);
    }
}
