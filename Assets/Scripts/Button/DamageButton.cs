using UnityEngine;

public class DamageButton : ButtonEvent
{
    [SerializeField] private Health _health;
    [SerializeField] private int _damageCount;

    protected override void HandleButtonClick()
    {
        _health.SubstractHealth(_damageCount);
    }
}
