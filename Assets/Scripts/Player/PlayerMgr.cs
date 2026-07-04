using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : MonoBehaviour
{
    private static PlayerMgr _instance;
    public static PlayerMgr Instance => _instance;
    void Awake()
    {
        if(_instance != null)
        {
            Debug.LogWarning("【单例重复挂载】" + "PlayerMgr");
            return;
        }
        _instance = this;
    }
}
