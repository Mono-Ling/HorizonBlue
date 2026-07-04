using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquip : SingleMono<PlayerEquip>
{
    public DivingSuit divingSuit = new DivingSuit(EquipQuality.Low);
    public Flipper flipper = new Flipper(EquipQuality.Low);
    public OxygenBottle oxygenBottle = new OxygenBottle(EquipQuality.Low);
    private Dictionary<Type,BaseEquip> equipMap = new Dictionary<Type, BaseEquip>();
    // Start is called before the first frame update
    void Start()
    {
        equipMap.Add(typeof(DivingSuit), divingSuit);
        equipMap.Add(typeof(Flipper), flipper);
        equipMap.Add(typeof(OxygenBottle), oxygenBottle);
        EventBus.Instance.AddListener<BaseEquip>(EventType.OnPlayerEquipChange, OnEquipChange);
    }
    private void OnEquipChange(BaseEquip equip)
    {
        Type type = equip.GetType();
        if (equipMap.ContainsKey(type))
        {
            equipMap[type].Uninstall();
            equipMap[type] = equip;
            equipMap[type].Install();

            // 同步更新 public 字段，否则 UpgradePanel 读取的是旧引用
            if (equip is DivingSuit ds)
                divingSuit = ds;
            else if (equip is Flipper fl)
                flipper = fl;
            else if (equip is OxygenBottle ob)
                oxygenBottle = ob;
        }
        else
            Debug.LogError("��δע��װ�����͡�" + type.ToString());
    }
    private void OnDestroy()
    {
        EventBus.Instance.RemoveListener<BaseEquip>(EventType.OnPlayerEquipChange, OnEquipChange);
    }
}
