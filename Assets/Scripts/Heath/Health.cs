using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _currentHeath;

    public event Action<float> HealthChanged;

    public int CurrentHealth => _currentHeath;
    public int MaxHealth => _maxHealth;
    public bool IsAlive => _currentHeath > 0;
    

    private void Start()
    {
        _currentHeath = _maxHealth;
        HealthChanged?.Invoke(_currentHeath);
    }

    public void SubstractHealth(int value)
    {
        if (value > 0)
        {
            _currentHeath = Mathf.Clamp(_currentHeath - Mathf.Clamp(value, 0, int.MaxValue), 0, _maxHealth);
            HealthChanged?.Invoke(_currentHeath);
        }
    }

    public void IncreaseHealth(int value)
    {
        if (value > 0)
        {
            _currentHeath = Mathf.Clamp(_currentHeath + Mathf.Clamp(value, 0, int.MaxValue), 0, _maxHealth);
            HealthChanged?.Invoke(_currentHeath);
        }
    }
}
