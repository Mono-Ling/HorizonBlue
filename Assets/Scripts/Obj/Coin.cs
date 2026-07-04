using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : BaseObj
{
    public int value = 1;
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GlobalValue.Instance.AddMoney(value);
            Destroy(gameObject);
        }
    }
}
