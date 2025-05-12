using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothBarHealthViewer : HealthViewer
{
    [SerializeField] private Slider _healthSmoothBar;
    [SerializeField] private float _speed = 1.0f;

    private Coroutine _currentCoroutine;

    protected override void DisplayView(float value)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(DisplaySmoothBar(value));
    }

    private IEnumerator DisplaySmoothBar(float targetValue)
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        
        while (Mathf.Approximately(_healthSmoothBar.value, targetValue) == false)
        {
            _healthSmoothBar.value = Mathf.MoveTowards(_healthSmoothBar.value, targetValue / _health.MaxValue, Time.deltaTime * _speed);
            yield return wait;
        }
    }
}
