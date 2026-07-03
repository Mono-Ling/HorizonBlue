using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : SingleMono<Oxygen>
{
    private const float _delayTime = 5.0f;
    private const int _changeFrame = 5;
    private int _multiply = 1;
    private int value = 100;
    private int maxValue = 100;
    private Coroutine coroutine;
    // Start is called before the first frame update
    void Start()
    {
        EventBus.Instance.AddListener<int>(EventType.OxygenChange,OxygenChange);
        EventBus.Instance.AddListener<int>(EventType.MaxOxygenChange,MaxOxygenChange);
        EventBus.Instance.AddListener<float>(EventType.OxygenDeclineSpeed,MultiplyChange);
    }
    public void StartReduce()
    {
        coroutine = StartCoroutine(Reduce());
    }
    public void StopReduce()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = null;
    }
    private IEnumerator Reduce()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delayTime);
            OxygenChange(-_multiply * _changeFrame);
        }
    }
    private void MultiplyChange(float delta)
    {
        _multiply = Mathf.Max(1, (int)delta);
    }
    private void OxygenChange(int value)
    {
        this.value += value;
        if(value <= 0)
            EventBus.Instance.TriggerEvent(EventType.OnPlayerDie);
        this.value = Mathf.Clamp(this.value, 0, maxValue);
        EventBus.Instance.TriggerEvent<int>(EventType.OnOxygenChange, value);
    }
    private void MaxOxygenChange(int value)
    {
        this.maxValue = value;
        this.maxValue = Mathf.Max(0, maxValue);
        EventBus.Instance.TriggerEvent(EventType.OnMaxOxygenChange, maxValue);
    }
    private void OnDestroy()
    {
        EventBus.Instance.RemoveListener<int>(EventType.OxygenChange, OxygenChange);
        EventBus.Instance.RemoveListener<int> (EventType.MaxOxygenChange, MaxOxygenChange);
        EventBus.Instance.RemoveListener<float>(EventType.OxygenDeclineSpeed, MultiplyChange);
    }
}
