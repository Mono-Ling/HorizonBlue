using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public abstract class BaseUI : MonoBehaviour
{
    public float showDuration = 0.5f;
    public float hideDuration = 0.5f;
    protected CanvasGroup canvasGroup;
    protected bool isShow = false;
    protected UnityAction showCallback;
    protected UnityAction hideCallback;
    protected float startTime;
    protected virtual void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }
    protected virtual void Update()
    {
        if (isShow)
            OnShowAnimation();
        else
            OnHideAnimation();
    }
    protected abstract void OnInit();
    public virtual void OnShow(UnityAction callback)
    {
        canvasGroup.alpha = 0;
        isShow = true;
        showCallback = callback;
        startTime = Time.time;
    }
    public virtual void OnHide(UnityAction callback)
    {
        isShow = false;
        hideCallback = callback;
        startTime = Time.time;
    }
    protected virtual void OnShowAnimation()
    {
        if(Time.time - startTime < showDuration)
        {
            canvasGroup.alpha = (Time.time - startTime) / showDuration;
        }
        else
        {
            canvasGroup.alpha = 1;
            showCallback?.Invoke();
            showCallback = null;
        }
    }
    protected virtual void OnHideAnimation()
    {
        if(Time.time - startTime < hideDuration)
        {
            canvasGroup.alpha = 1 - (Time.time - startTime) / hideDuration;
        }
        else
        {
            canvasGroup.alpha = 0;
            hideCallback?.Invoke();
            hideCallback = null;
        }
    }
}
