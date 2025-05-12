using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothBarHealthViewer : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _healthSmoothBar;
    [SerializeField] private float _smoothSpeed = 1.0f;

    private Coroutine _currentCoroutine;

    private void OnEnable()
    {
        _health.HealthChanged += SetTargetValue;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= SetTargetValue;
    }

    private void SetTargetValue(float value)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(SmoothBarView(value));
    }

    private IEnumerator SmoothBarView(float targetValue)
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();

        while (_healthSmoothBar.value != targetValue)
        {
            _healthSmoothBar.value = Mathf.MoveTowards(_healthSmoothBar.value, targetValue / _health.MaxHealth, Time.deltaTime * _smoothSpeed);
            yield return wait;
        }
    }
}
