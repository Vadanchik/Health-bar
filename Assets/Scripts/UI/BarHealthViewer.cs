using UnityEngine;
using UnityEngine.UI;

public class BarHealthViewer : HealthViewer
{
    [SerializeField] private Slider _healthBar;

    protected override void DisplayView(float value)
    {
        _healthBar.value = value / _health.MaxValue;
    }
}
