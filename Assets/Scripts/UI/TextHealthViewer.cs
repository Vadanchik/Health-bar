using TMPro;
using UnityEngine;

public class TextHealthViewer : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TMP_Text _healthText;

    private void OnEnable()
    {
        _health.HealthChanged += TextView;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= TextView;
    }

    private void TextView(float value)
    {
        _healthText.text = value.ToString() + "/" + _health.MaxHealth;
    }
}
