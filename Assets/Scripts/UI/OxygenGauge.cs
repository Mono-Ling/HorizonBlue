using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OxygenGauge : BaseUI
{
    public Image _gaugeImage;
    public TextMeshProUGUI _oxygenText;
    private int _currentOxygen = 0;
    private int _maxOxygen = 0;
    protected override void OnInit()
    {
        if(_gaugeImage == null)
            Debug.LogError("【空引用】GaugeImage is null");
        if(_oxygenText == null)
            Debug.LogError("【空引用】OxygenText is null");
        EventBus.Instance.AddListener<int>(EventType.OnOxygenChange, GetCurrentOxygen);
        EventBus.Instance.AddListener<int>(EventType.OnMaxOxygenChange, GetMaxOxygen);
    }
    public void GetCurrentOxygen(int value)
    {
        _currentOxygen = value;
        float fillAmount = (float)_currentOxygen / Mathf.Clamp01(_maxOxygen);
        _gaugeImage.fillAmount = fillAmount;
        _oxygenText.text = $"{_currentOxygen}/{_maxOxygen}";
    }
    public void GetMaxOxygen(int value)
    {
        _maxOxygen = value;
        float fillAmount = (float)_currentOxygen / Mathf.Clamp01(_maxOxygen);
        _gaugeImage.fillAmount = fillAmount;
        _oxygenText.text = $"{_currentOxygen}/{_maxOxygen}";
    }
    void OnDestroy()
    {
        EventBus.Instance.RemoveListener<int>(EventType.OnOxygenChange, GetCurrentOxygen);
        EventBus.Instance.RemoveListener<int>(EventType.OnMaxOxygenChange, GetMaxOxygen);
    }
}
