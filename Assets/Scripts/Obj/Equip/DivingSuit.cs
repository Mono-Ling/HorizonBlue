using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivingSuit : BaseEquip
{
    public DivingSuit(EquipQuality quality)
    {
        this.quality = quality;
    }
    override public void Install()
    {
        switch (quality)
        {
            case EquipQuality.Low:
                EventBus.Instance.TriggerEvent(EventType.OnMaxDeepChange, 100);
                break;
            case EquipQuality.Middle:
                EventBus.Instance.TriggerEvent(EventType.OnMaxDeepChange, int.MaxValue);
                break;
            case EquipQuality.High:
                EventBus.Instance.TriggerEvent(EventType.OnMaxDeepChange, int.MaxValue);
                EventBus.Instance.TriggerEvent(EventType.PlayerLightingChange, true);
                break;
        }
    }
    override public void Uninstall()
    {
        EventBus.Instance.TriggerEvent(EventType.OnMaxDeepChange, 100);
        EventBus.Instance.TriggerEvent(EventType.PlayerLightingChange, false);
    }
}
