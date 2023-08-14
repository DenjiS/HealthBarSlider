using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private int _changeRate;
    [SerializeField] private float _changeTime;

    private Slider _healthSlider;
    private WaitForSeconds _changeDelay;

    private Coroutine _changeCoroutine;

    private void Awake()
    {
        _healthSlider = GetComponent<Slider>();
        _healthSlider.maxValue = _health.MaxAmount;

        _changeDelay = new WaitForSeconds(_changeTime);
    }

    private void OnEnable()
    {
        _health.Changed.AddListener(OnChanged);
    }

    private void OnDisable()
    {
        _health.Changed.RemoveListener(OnChanged);
    }

    private void OnChanged(int value)
    {
        if (_changeCoroutine != null)
        {
            StopCoroutine(_changeCoroutine);
        }

        _changeCoroutine = StartCoroutine(MoveValue(value));
    }

    private IEnumerator MoveValue(int value)
    {
        while (_healthSlider.value != value)
        {
            _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, value, _changeRate);

            yield return _changeDelay;
        }
    }
}