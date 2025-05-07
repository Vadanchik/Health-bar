using UnityEngine;

public class HealButton : ButtonEvent
{
    [SerializeField] private Health _health;
    [SerializeField] private int _healCount;

    protected override void HandleButtonClick()
    {
        _health.IncreaseHealth(_healCount);
    }
}
