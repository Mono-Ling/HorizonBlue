using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongAttack : BaseObj
{
    override protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GlobalValue.Instance.AddMoney(int.MaxValue);
            Destroy(gameObject);
        }
    }
}