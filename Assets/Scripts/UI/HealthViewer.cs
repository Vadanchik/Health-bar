using UnityEngine;

public abstract class HealthViewer : MonoBehaviour
{
    [SerializeField] protected Health _health;

    private void OnEnable()
    {
        _health.ValueChanged += DisplayView;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= DisplayView;
    }

    protected abstract void DisplayView(float value);
}
