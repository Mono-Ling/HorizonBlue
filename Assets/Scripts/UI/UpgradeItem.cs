using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class UpgradeItem : MonoBehaviour
{
    public TextMeshProUGUI _itemTitle;
    public TextMeshProUGUI _itemLevel;
    public Button button;
    public event UnityAction buttonEvent;
    // Start is called before the first frame update
    void Start()
    {
        if(button == null)
            Debug.LogError("【空引用】Button is null");
        if(_itemTitle == null)
            Debug.LogError("【空引用】ItemTitle is null");
        if(_itemLevel == null)
            Debug.LogError("【空引用】ItemLevel is null");
        button.onClick.AddListener(()=> buttonEvent?.Invoke());
    }
    public void SetItemTitle(string title)
    {
        _itemTitle.text = title;
    }
    public void SetItemLevel(int level)
    {
        _itemLevel.text = $"Lv.{level}";
    }
    public void SetBottonState(bool isShow)
    {
        button.gameObject.SetActive(isShow);
    }
}
