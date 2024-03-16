using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
	[SerializeField] float baseValue = 10f;

    private float currentValue = 10f;
    public float CurrentValue => currentValue;

    public event Action<float> OnValueChangedEvent = null;

    private List<float> modifiers = new List<float>();

    public void Clear()
    {
        modifiers.Clear();
        currentValue = baseValue;   
    }

    public void CalculateValue()
    {
        currentValue = baseValue;

        modifiers.ForEach(i => currentValue += i);
        OnValueChangedEvent?.Invoke(currentValue);
    }

    public void SetBaseValue(float value)
    {
        baseValue = value;
        CalculateValue();
    }

    public void AddModifier(float modifier)
    {
        modifiers.Add(modifier);
        CalculateValue();
    }

    public void RemoveModifier(float modifier)
    {
        modifiers.Remove(modifier);
        CalculateValue();
    }
}
