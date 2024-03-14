using System;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Player/Wallet")]
public class PlayerWallet : ScriptableObject
{
    [SerializeField] int money = 0;
	public int Money => money;

    // <now, amount>
    public event Action<int, int> OnMoneyValueChanged = null;

    public bool CheckEnough(int amount) => money >= amount;

    public void ModifyMoney(int amount)
    {
        money += amount;
        OnMoneyValueChanged?.Invoke(money, amount);
    }
}
