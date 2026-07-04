using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAttack : BaseObj
{
    public float damageMultiplier = 1f;
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventBus.Instance.TriggerEvent(EventType.OxygenDeclineSpeed, damageMultiplier);
        }
    }
}
