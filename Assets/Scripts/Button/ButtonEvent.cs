using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonEvent : MonoBehaviour
{
    private Button _button;

    protected virtual void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(HandleButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(HandleButtonClick);
    }

    protected virtual void HandleButtonClick() { }
}