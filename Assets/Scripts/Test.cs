using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GlobalValue.Instance.Init();
        PlayerEquip.Instance.Init();
        GameManager.Instance.Init();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            EventBus.Instance.TriggerEvent<BaseEquip>(EventType.OnPlayerEquipChange, new Flipper(EquipQuality.High));
    }
}
