using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MemonyPanel : BaseUI
{
    public TextMeshProUGUI text;
    protected override void OnInit()
    {
        if(!text)
        {
            Debug.LogError("【空引用】 text is null");
            return;
        }
        text.text = "0";
        EventBus.Instance.AddListener<int>(EventType.OnMoneyChange,MemonyChange);
    }
    private void MemonyChange(int value)
    {
        text.text = value.ToString();
    }
    void OnDestroy()
    {
        EventBus.Instance.RemoveListener<int>(EventType.OnMoneyChange,MemonyChange);
    }
}
