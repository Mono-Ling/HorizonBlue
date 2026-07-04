using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButUpgrade : BaseUI
{
    public Button button;
    protected override void OnInit()
    {
        if(!button)
        {
            Debug.LogError("【空引用】button is null");
            return;
        }
        button.onClick.AddListener(OpenUpgradePanel);
    }
    private void OpenUpgradePanel()
    {
        UIManager.Instance.ShowUI<UpgradePanel>();
    }
}
