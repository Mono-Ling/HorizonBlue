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
                GlobalValue.Instance.SetPlayerSpeed(GlobalValue.PlayerSpeed.Slow);
                break;
            case EquipQuality.Middle:
                GlobalValue.Instance.SetPlayerSpeed(GlobalValue.PlayerSpeed.Normal);
                break;
            case EquipQuality.High:
                GlobalValue.Instance.SetPlayerSpeed(GlobalValue.PlayerSpeed.Fast);
                break;
        }
    }
    override public void Uninstall()
    {
        GlobalValue.Instance.SetPlayerSpeed(GlobalValue.PlayerSpeed.Slow);
    }
}
