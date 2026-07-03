using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEquip
{
    public EquipQuality quality;
    public abstract void Install();
    public abstract void Uninstall();
}
public enum EquipQuality
{
    Low = 1,
    Middle = 2,
    High = 3,
}
