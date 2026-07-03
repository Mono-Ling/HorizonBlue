using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager
{
    private static UIManager _instance;
    public static UIManager Instance => _instance ??= new UIManager();
    private Transform canvasTransform;
    private UIManager()
    {
        GameObject canvas = GameObject.Instantiate(Resources.Load<GameObject>("UI/UICanvas"));
        if(canvas == null)
        {
            Debug.LogError("【UI初始化失败】UICanvas prefab not found in Resources/UI/");
            return;
        }
        canvas.name = "UICanvas";
        GameObject.DontDestroyOnLoad(canvas);
        canvasTransform = canvas.transform;
    }
    private Dictionary<string, BaseUI> uiDict = new Dictionary<string, BaseUI>();
    public T GetUI<T>() where T : BaseUI
    {
        string uiName = typeof(T).Name;
        if (uiDict.ContainsKey(uiName))
        {
            return uiDict[uiName] as T;
        }
        Debug.LogError($"【UI获取失败】UI {uiName} not found in UIManager.");
        return null;
    }
    public void ShowUI<T>(UnityAction callback = null) where T : BaseUI
    {
        string uiName = typeof(T).Name;
        if (uiDict.ContainsKey(uiName))
        {
            Debug.LogWarning($"【UI显示警告】UI {uiName} is already shown.");
            return;
        }
        GameObject uiPrefab = Resources.Load<GameObject>($"UI/{uiName}");
        if (uiPrefab == null)
        {
            Debug.LogError($"【UI显示失败】UI prefab {uiName} not found in Resources/UI/");
            return;
        }
        GameObject uiInstance = GameObject.Instantiate(uiPrefab, canvasTransform);
        BaseUI baseUI = uiInstance.GetComponent<BaseUI>();
        uiDict.Add(uiName, baseUI);
        baseUI.OnShow(callback);
    }
    public void HideUI<T>(UnityAction callback = null) where T : BaseUI
    {
        string uiName = typeof(T).Name;
        if (!uiDict.ContainsKey(uiName))
        {
            Debug.LogWarning($"【UI隐藏警告】UI {uiName} is not shown.");
            return;
        }
        BaseUI baseUI = uiDict[uiName];
        baseUI.OnHide(() =>
        {
            GameObject.Destroy(baseUI.gameObject);
            uiDict.Remove(uiName);
            callback?.Invoke();
        });
    }
}
