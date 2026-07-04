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
        int delat = _defaultOxygenAmount * (int)quality;
        EventBus.Instance.TriggerEvent(EventType.MaxOxygenChange, delat);
        EventBus.Instance.TriggerEvent(EventType.OxygenChange,delat);
    }
    public override void Uninstall()
    {
        //EventBus.Instance.TriggerEvent(EventType.MaxOxygenChange, _defaultOxygenAmount);
    }
}
