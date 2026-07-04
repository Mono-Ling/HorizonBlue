using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenGauge : MonoBehaviour
{
    public Image _gaugeImage;
    private int _currentOxygen = 0;
    private int _maxOxygen = 0;
    public void Start()
    {
        EventBus.Instance.AddListener<int>(EventType.OnOxygenChange, GetCurrentOxygen);
        EventBus.Instance.AddListener<int>(EventType.OnMaxOxygenChange, GetMaxOxygen);
    }
    public void GetCurrentOxygen(int value)
    {
        _currentOxygen = value;
        float fillAmount = (float)_currentOxygen / Mathf.Clamp01(_maxOxygen);
        _gaugeImage.fillAmount = fillAmount;
    }
    public void GetMaxOxygen(int value)
    {
        _maxOxygen = value;
        float fillAmount = (float)_currentOxygen / Mathf.Clamp01(_maxOxygen);
        _gaugeImage.fillAmount = fillAmount;
    }
    void OnDestroy()
    {
        EventBus.Instance.RemoveListener<int>(EventType.OnOxygenChange, GetCurrentOxygen);
        EventBus.Instance.RemoveListener<int>(EventType.OnMaxOxygenChange, GetMaxOxygen);
    }
}
