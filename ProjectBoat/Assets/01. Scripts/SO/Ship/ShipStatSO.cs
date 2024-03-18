using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Ship/ShipStat")]
public class ShipStatSO : ScriptableObject
{
	public Stat Durability = new Stat();
    public Stat RateOfTurn = new Stat();
    public Stat TopSpeed = new Stat();
    public Stat AccelSpeed = new Stat();
    public Stat Weight = new Stat();

    protected Dictionary<StatType, Stat> stats = null;

    public Stat this[StatType index] => stats[index];

    private void OnEnable()
    {
        if(stats == null)
            stats = new Dictionary<StatType, Stat>();

        stats.Clear();

        Type characterStatType = GetType();
        foreach(StatType statType in Enum.GetValues(typeof(StatType)))
        {
            FieldInfo statField = characterStatType.GetField(statType.ToString());
            if(statField != null)
            {
                stats.Add(statType, statField.GetValue(this) as Stat);
                stats[statType].CalculateValue();
            }
        }
    }

    private void OnValidate()
    {
        OnEnable();
    }
}
