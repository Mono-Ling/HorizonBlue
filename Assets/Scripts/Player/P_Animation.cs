using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Animation : MonoBehaviour
{
    private Animator animator;
    private const string _horizontal = "horizontal";
    private const string _vertical = "vertical";
    private const string _isDie = "isDie";
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if(!animator)
            Debug.LogError("【空引用】animator is null");
        EventBus.Instance.AddListener<Vector2>(EventType.PlayerMove,GetDir);
    }

    private void GetDir(Vector2 dir)
    {
        if(dir.magnitude > 0.5)
        {
            animator.SetFloat(_horizontal,1);
            animator.SetFloat(_vertical,1);
        }
        else
        {
            animator.SetFloat(_horizontal,-1);
            animator.SetFloat(_vertical,-1);
        }
    }
    private void PlayerDie() => animator.SetBool(_isDie,true);
    void OnDestroy()
    {
        EventBus.Instance.RemoveListener<Vector2>(EventType.PlayerMove,GetDir);
    }
}
