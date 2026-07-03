using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : BaseObj
{
    public int damage = 1;
    protected override void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GlobalValue.Instance.RemoveOxygen(damage);
            Destroy(gameObject);
        }
    }
}
