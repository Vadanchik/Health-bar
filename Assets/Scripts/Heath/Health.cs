using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue;
    private int _currentValue;

    public event Action<float> ValueChanged;

    public int CurrentValue => _currentValue;
    public int MaxValue => _maxValue;
    public bool IsAlive => _currentValue > 0;

    private void Start()
    {
        _currentValue = _maxValue;
        ValueChanged?.Invoke(_currentValue);
    }

    public void SubstractHealth(int value)
    {
        if (value > 0)
        {
            _currentValue = Mathf.Clamp(_currentValue - value, 0, _maxValue);
            ValueChanged?.Invoke(_currentValue);
        }
    }

    public void IncreaseHealth(int value)
    {
        if (value > 0)
        {
            _currentValue = Mathf.Clamp(_currentValue + value, 0, _maxValue);
            ValueChanged?.Invoke(_currentValue);
        }
    }
}
