using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxAmount;

    private int _current;

    public UnityEvent<int> Changed;

    public int MaxAmount => _maxAmount;

    private void Start()
    {
        _current = _maxAmount;

        Changed.Invoke(_current);
    }

    public void Change(int amount)
    {
        _current += amount;
        _current = Mathf.Clamp(_current, 0, _maxAmount);

        Changed.Invoke(_current);
    }
}
