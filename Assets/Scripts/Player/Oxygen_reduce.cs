using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen_reduce : MonoBehaviour
{
    public float Current_Oxygen;
    private float ODS = 1f;
    public float timer = 0;

    private void Start()
    {
        EventBus.Instance.AddListener<float>(EventType.OxygenDeclineSpeed,Oxygen_Decline );
    }

    private void Update()
    {
        timer += Time.deltaTime;
        OxygenDeclineSpeed();
    }
    public void Oxygen_Decline(float f)
    {
         ODS = f;
        if (timer > 1)
        {
            if ((Current_Oxygen >= 0) && (Current_Oxygen - ODS) >= 0)
                Current_Oxygen -= ODS;
            else
            {
                Current_Oxygen = 0;
            }
            timer = 0;
        }
    }
    public void OxygenDeclineSpeed()
    {
        EventBus.Instance.TriggerEvent(EventType.OxygenDeclineSpeed, ODS);
    }

    private void OnDestroy()
    {
        EventBus.Instance.RemoveListener<float>(EventType.OxygenDeclineSpeed, Oxygen_Decline);
    }
}
