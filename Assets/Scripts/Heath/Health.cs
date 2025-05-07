using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHeath;

    public int CurrentHealth => _currentHeath;
    public int MaxHealth => _maxHealth;
    public bool IsAlive => _currentHeath > 0;

    public event Action<float> HealthChanged;

    private void Start()
    {
        _currentHeath = _maxHealth;
        HealthChanged?.Invoke(_currentHeath);
    }

    public void SubstractHealth(int value)
    {
        _currentHeath = Mathf.Clamp(_currentHeath - Mathf.Clamp(value, 0, int.MaxValue), 0, _maxHealth);
        HealthChanged?.Invoke(_currentHeath);
    }

    public void IncreaseHealth(int value)
    {
        _currentHeath = Mathf.Clamp(_currentHeath + Mathf.Clamp(value, 0, int.MaxValue), 0, _maxHealth);
        HealthChanged?.Invoke(_currentHeath);
    }
}
