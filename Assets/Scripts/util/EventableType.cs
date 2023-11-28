using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EventableType<T> where T : unmanaged, IComparable<T>, IEquatable<T>
{
    [SerializeField] private T _value;

    public EventableType(T initValue) {
        _value = initValue;
    }
    public Action<T, T> OnValueChanged;
    public T Value
    {
        get => _value;
        set
        {
            if (_value.Equals(value))
                return;

            var old = _value;
            _value = value;
            OnValueChanged?.Invoke(old, value);
        }
    }
    public static implicit operator T(EventableType<T> eventableType) => eventableType.Value;
}