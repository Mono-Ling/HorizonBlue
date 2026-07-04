using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeepGauge : BaseUI
{
    public Image _gaugeImage;
    public int _currentDeep = 0;
    public int _maxDeep = 100;
    protected override void OnInit()
    {
        if(_gaugeImage == null)
            Debug.LogError("【空引用】GaugeImage is null");
        EventBus.Instance.AddListener<int>(EventType.OnMaxDeepChange, GetMaxDeep);
        EventBus.Instance.AddListener<int>(EventType.OnCurrentDeepChange, GetCurrentDeep);
    }
    private void GetCurrentDeep(int value)
    {
        _currentDeep = value;
        _gaugeImage.fillAmount = (float)_currentDeep / Mathf.Max(1, _maxDeep);
    }
    private void GetMaxDeep(int value)
    {
        _maxDeep = value;
        _gaugeImage.fillAmount = (float)_currentDeep / Mathf.Max(1, _maxDeep);
    }
    void OnDestroy()
    {
        EventBus.Instance.RemoveListener<int>(EventType.OnMaxDeepChange, GetMaxDeep);
        EventBus.Instance.RemoveListener<int>(EventType.OnCurrentDeepChange, GetCurrentDeep);
    }
}
