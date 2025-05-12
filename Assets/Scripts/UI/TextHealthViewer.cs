using TMPro;
using UnityEngine;

public class TextHealthViewer : HealthViewer
{
    [SerializeField] private TMP_Text _healthText;

    protected override void DisplayView(float value)
    {
        _healthText.text = value.ToString() + "/" + _health.MaxValue;
    }
}
