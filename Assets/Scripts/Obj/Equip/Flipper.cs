using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : BaseEquip
{
    public Flipper(EquipQuality quality)
    {
        this.quality = quality;
    }
    override public void Install()
    {
        switch (quality)
        {
            case EquipQuality.Low:
                EventBus.Instance.TriggerEvent(EventType.OnPlayerSpeedChange, GlobalValue.PlayerSpeed.Slow);
                break;
            case EquipQuality.Middle:
                EventBus.Instance.TriggerEvent(EventType.OnPlayerSpeedChange, GlobalValue.PlayerSpeed.Normal);
                break;
            case EquipQuality.High:
                EventBus.Instance.TriggerEvent(EventType.OnPlayerSpeedChange, GlobalValue.PlayerSpeed.Fast);
                break;
        }
    }
    override public void Uninstall()
    {
        EventBus.Instance.TriggerEvent(EventType.OnPlayerSpeedChange, GlobalValue.PlayerSpeed.Slow);
    }
}
