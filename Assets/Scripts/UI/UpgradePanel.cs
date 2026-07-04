using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : BaseUI
{
    public UpgradeItem divingSuitItem;
    public UpgradeItem oxygenBottleItem;
    public UpgradeItem flipperItem;
    public Button quitButton;
    override protected void OnInit()
    {
        if(divingSuitItem == null)
            Debug.LogError("【空引用】DivingSuitItem is null");
        if(oxygenBottleItem == null)
            Debug.LogError("【空引用】OxygenBottleItem is null");
        if(flipperItem == null)
            Debug.LogError("【空引用】FilpperItem is null");
        if(quitButton == null)
            Debug.LogError("【空引用】quitButton is null");

        quitButton.onClick.AddListener(Quit);
        
        divingSuitItem.SetItemTitle("潜水服");
        oxygenBottleItem.SetItemTitle("氧气瓶");
        flipperItem.SetItemTitle("脚蹼");

        divingSuitItem.SetItemLevel((int)PlayerEquip.Instance.divingSuit.quality);
        oxygenBottleItem.SetItemLevel((int)PlayerEquip.Instance.oxygenBottle.quality);
        flipperItem.SetItemLevel((int)PlayerEquip.Instance.flipper.quality);

        bool canUpgrade = GlobalValue.Instance.money > 0;
        divingSuitItem.SetBottonState(canUpgrade);
        oxygenBottleItem.SetBottonState(canUpgrade);
        flipperItem.SetBottonState(canUpgrade);

        divingSuitItem.buttonEvent += OnClickDivingSuitUpgrade;
        oxygenBottleItem.buttonEvent += OnClickOxygenBottleUpgrade;
        flipperItem.buttonEvent += OnClickFlipperUpgrade;
    }
    public void OnClickDivingSuitUpgrade()
    {
        EquipQuality quality = (EquipQuality)Mathf.Clamp((int)PlayerEquip.Instance.divingSuit.quality + 1,1,3);
        EventBus.Instance.TriggerEvent<BaseEquip>(EventType.OnPlayerEquipChange, new DivingSuit(quality));
        if(!GlobalValue.Instance.RemoveMoney(1))
            Debug.LogWarning("【升级金币溢出】");
        divingSuitItem.SetItemLevel((int)quality);
        UpdateButton();
    }
    public void OnClickOxygenBottleUpgrade()
    {
        EquipQuality quality = (EquipQuality)Mathf.Clamp((int)PlayerEquip.Instance.oxygenBottle.quality + 1,1,3);
        EventBus.Instance.TriggerEvent<BaseEquip>(EventType.OnPlayerEquipChange, new OxygenBottle(quality));
        if(!GlobalValue.Instance.RemoveMoney(1))
            Debug.LogWarning("【升级金币溢出】");
        oxygenBottleItem.SetItemLevel((int)quality);
        UpdateButton();
    }
    public void OnClickFlipperUpgrade()
    {
        EquipQuality quality = (EquipQuality)Mathf.Clamp((int)PlayerEquip.Instance.flipper.quality + 1,1,3);
        EventBus.Instance.TriggerEvent<BaseEquip>(EventType.OnPlayerEquipChange, new Flipper(quality));
        if(!GlobalValue.Instance.RemoveMoney(1))
            Debug.LogWarning("【升级金币溢出】");
        flipperItem.SetItemLevel((int)quality);
        UpdateButton();
    }
    private void UpdateButton()
    {
        bool canUpgradel = GlobalValue.Instance.money > 0;
        divingSuitItem.SetBottonState(canUpgradel);
        oxygenBottleItem.SetBottonState(canUpgradel);
        flipperItem.SetBottonState(canUpgradel);
    }
    private void Quit()
    {
        UIManager.Instance.HideUI<UpgradePanel>();
    }
}
