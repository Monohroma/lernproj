using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public abstract class Model
{
    [SerializeField] protected string _name;

    public UnityEvent OnChange;

    public bool SetData<T>(ref T field, T value)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
        {
            return false;
        }

        field = value;
        OnChange.Invoke();

        return true;
    }
}