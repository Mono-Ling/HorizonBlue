using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValue : SingleMono<GlobalValue>
{
    public enum PlayerSpeed
    {
        Slow = 10,
        Normal = 50,
        Fast = 100,
    }
    public int money = 0;
    public int oxygen = 100;
    public int maxOxygen = 100;
    public PlayerSpeed playerSpeed = PlayerSpeed.Slow;
    public void AddMoney(int value)
    {
        money += value;
        EventBus.Instance.TriggerEvent<int>(EventType.OnMoneyChange, money);
    }
    public bool RemoveMoney(int value)
    {
        money -= value;
        if (money < 0)
        {
            money += value;
            return false;
        }
        money = Mathf.Max(0, money);
        EventBus.Instance.TriggerEvent<int>(EventType.OnMoneyChange, money);
        return true;
    }
    public void AddOxygen(int value)
    {
        oxygen += value;
        oxygen = Mathf.Min(oxygen, maxOxygen);
        EventBus.Instance.TriggerEvent<int>(EventType.OnOxygenChange, oxygen);
    }
    public void RemoveOxygen(int value)
    {
        oxygen -= value;
        if(oxygen <= 0)
            EventBus.Instance.TriggerEvent(EventType.OnPlayerDie);
        oxygen = Mathf.Max(0, oxygen);
        EventBus.Instance.TriggerEvent<int>(EventType.OnOxygenChange, oxygen);
    }
    public void SetPlayerSpeed(PlayerSpeed speed)
    {
        EventBus.Instance.TriggerEvent<int>(EventType.OnPlayerSpeedChange, (int)speed);
    }
}
