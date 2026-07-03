using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBus
{
    private static EventBus _instance;
    public static EventBus Instance => _instance ?? (_instance = new EventBus());
    private abstract class EventBase { }
    private class Event<T> : EventBase
    {
        public event UnityAction<T> action;
        public void Trigger(T args) => action?.Invoke(args);
    }
    private class Event : EventBase
    {
        public event UnityAction action;
        public void Trigger() => action?.Invoke();
    }
    private Dictionary<EventType, EventBase> eventDic = new Dictionary<EventType, EventBase>();
    public void AddListener<T>(EventType eventType, UnityAction<T> action)
    {
        if (!eventDic.ContainsKey(eventType))
        {
            Event<T> newEvent = new Event<T>();
            newEvent.action += action;
            eventDic.Add(eventType, newEvent);
        }
        else
        {
            if(eventDic[eventType] is Event<T> existingEvent)
                existingEvent.action += action;
            else
                Debug.LogError($"【事件总线】事件类型不匹配: {eventType}. 期望类型: {typeof(T)}, 实际类型: {eventDic[eventType].GetType()}");
        }
    }
    public void AddListener(EventType eventType, UnityAction action)
    {
        if (!eventDic.ContainsKey(eventType))
        {
            Event newEvent = new Event();
            newEvent.action += action;
            eventDic.Add(eventType, newEvent);
        }
        else
        {
            if (eventDic[eventType] is Event existingEvent)
                existingEvent.action += action;
            else
                Debug.LogError($"【事件总线】事件类型不匹配: {eventType}. 期望类型: 无参, 实际类型: {eventDic[eventType].GetType()}");
        }
    }
    public void RemoveListener<T>(EventType eventType, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(eventType))
        {
            if (eventDic[eventType] is Event<T> existingEvent)
                existingEvent.action -= action;
            else
                Debug.LogError($"【事件总线】事件类型不匹配: {eventType}. 期望类型: {typeof(T)}, 实际类型: {eventDic[eventType].GetType()}");
        }
        else
            Debug.LogWarning($"【事件总线】未找到事件类型: {eventType}");
    }
    public void RemoveListener(EventType eventType, UnityAction action)
    {
        if (eventDic.ContainsKey(eventType))
        {
            if(eventDic[eventType] is Event existingEvent)
                existingEvent.action -= action;
            else
                Debug.LogError($"【事件总线】事件类型不匹配: {eventType}; 期望类型: 无参, 实际类型: {eventDic[eventType].GetType()}");
        }
        else
            Debug.LogWarning($"【事件总线】未找到事件类型: {eventType}");
    }
    public void TriggerEvent<T>(EventType eventType, T args)
    {
        if (eventDic.ContainsKey(eventType))
        {
            if (eventDic[eventType] is Event<T> existingEvent)
                existingEvent.Trigger(args);
            else
                Debug.LogError($"【事件总线】事件类型不匹配: {eventType}. 期望类型: {typeof(T)}, 实际类型: {eventDic[eventType].GetType()}");
        }
        else
            Debug.LogWarning($"【事件总线】未找到事件类型: {eventType}");
    }
    public void TriggerEvent(EventType eventType)
    {
        if (eventDic.ContainsKey(eventType))
        {
            if(eventDic[eventType] is Event existingEvent)
                existingEvent.Trigger();
            else
                Debug.LogError($"【事件总线】事件类型不匹配: {eventType}. 期望类型: 无参, 实际类型: {eventDic[eventType].GetType()}");
        }
        else
            Debug.LogWarning($"【事件总线】未找到事件类型: {eventType}");
    }
    public void Clear()
    {
        eventDic.Clear();
    }
}