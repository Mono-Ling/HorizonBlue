using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValue : SingleMono<GlobalValue>
{
    public enum PlayerSpeed
    {
        Slow = 10,
        Normal = 15,
        Fast = 20,
    }
    public int money { get; private set; } = 0;
    public PlayerSpeed playerSpeed { get; private set; } = PlayerSpeed.Slow;
    public int maxDeep { get; private set; } = 70;
    public int currentDeep { get; private set; } = 0;
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
    public void SetPlayerSpeed(PlayerSpeed speed)
    {
        playerSpeed = speed;
        EventBus.Instance.TriggerEvent<int>(EventType.OnPlayerSpeedChange, (int)speed);
    }
    public void SetMaxDeep(int value)
    {
        maxDeep = value;
        EventBus.Instance.TriggerEvent<int>(EventType.OnMaxDeepChange, maxDeep);
    }
    public void SetCurrentDeep(int value)
    {
        currentDeep = value;
        if(currentDeep > maxDeep)
            EventBus.Instance.TriggerEvent(EventType.OnPlayerDie);
        EventBus.Instance.TriggerEvent(EventType.OnCurrentDeepChange, currentDeep);
    }
}
