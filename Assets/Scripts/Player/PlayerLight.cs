using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    public GameObject lightObj;
    // Start is called before the first frame update
    void Start()
    {
        if(!lightObj)
            Debug.LogError("【空引用】light is null");
        EventBus.Instance.AddListener<bool>(EventType.PlayerLightingChange,OpenLight);
        lightObj?.SetActive(false);
    }
    private void OpenLight(bool isOpen)
    {
        lightObj?.SetActive(isOpen);
    }
    void OnDestroy()
    {
        EventBus.Instance.RemoveListener<bool>(EventType.PlayerLightingChange,OpenLight);
    }
}
