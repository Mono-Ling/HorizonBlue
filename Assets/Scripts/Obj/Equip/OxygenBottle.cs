using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenBottle : BaseEquip
{
    private const int _defaultOxygenAmount = 100;
    public OxygenBottle(EquipQuality quality)
    {
        this.quality = quality;
    }
    override public void Install()
    {
        EventBus.Instance.TriggerEvent(EventType.MaxOxygenChange, _defaultOxygenAmount * (int)quality);
    }
    public override void Uninstall()
    {
        EventBus.Instance.TriggerEvent(EventType.MaxOxygenChange, _defaultOxygenAmount);
    }
}
