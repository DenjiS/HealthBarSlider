using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Slider _healthSlider;

    private void Awake()
    {
        _healthSlider = GetComponent<Slider>();
        _healthSlider.maxValue = _health.MaxAmount;
    }

    private void OnEnable()
    {
        _health.Changed.AddListener(OnChanged);
    }

    private void OnDisable()
    {
        _health.Changed.RemoveListener(OnChanged);
    }

    private void OnChanged(int health)
    {
        _healthSlider.value = health;
    }
}