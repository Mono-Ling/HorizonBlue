using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSound : MonoBehaviour
{
    public AudioClip shallowMusic;
    public AudioClip deepMusic;
    public int division = 70;

    private int _lastDepth;
    // Start is called before the first frame update
    void Start()
    {
        EventBus.Instance.AddListener<int>(EventType.OnCurrentDeepChange,GetCurrDeep);
    }
    private void GetCurrDeep(int currentDepth)
    {
        if (shallowMusic == null || deepMusic == null)
        {
            Debug.LogWarning("浅海/深海音乐资源未赋值！", this);
            _lastDepth = currentDepth;
            return;
        }

        bool lastIsDeep = _lastDepth > division;
        bool currIsDeep = currentDepth > division;

        // 仅跨阈值时切换音乐
        if (!lastIsDeep && currIsDeep)
        {
            AudioManager.Instance.SwitchMusic(deepMusic);
        }
        else if (lastIsDeep && !currIsDeep)
        {
            AudioManager.Instance.SwitchMusic(shallowMusic);
        }

        // 更新缓存深度
        _lastDepth = currentDepth;
    }
    void OnDestroy()
    {
        EventBus.Instance.RemoveListener<int>(EventType.OnCurrentDeepChange,GetCurrDeep);
    }
}
