using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : BaseObj
{
    public int damage = 1;
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            EventBus.Instance.TriggerEvent(EventType.OxygenChange, damage);
            Destroy(gameObject);
        }
    }
}
