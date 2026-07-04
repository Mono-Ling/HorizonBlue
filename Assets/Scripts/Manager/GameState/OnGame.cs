using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGame : BaseState
{
    private Transform playerTransform;
    private Rigidbody2D playerRb;
    private bool isInEvacuateZone;
    private float cooldownRemaining;

    /// <summary>从锚上脱落后、撤离触发生效前的空窗期时长（秒）</summary>
    private const float EvacuateCooldown = 10f;

    public override void EnterState()
    {
        // 切换到玩家输入模式
        InputManager.Instance.EnablePlayerInput();

        // 确保玩家不作为任何物体的子对象
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
            playerRb = player.GetComponent<Rigidbody2D>();

            playerTransform.SetParent(null);
            if (playerRb != null)
            {
                playerRb.isKinematic = false;
                playerRb.velocity = Vector2.zero;
            }
        }

        // 监听撤离区域触发事件
        EventBus.Instance.AddListener(EventType.PlayerEnterEvacuate, OnPlayerEnterEvacuate);
        EventBus.Instance.AddListener(EventType.PlayerExitEvacute, OnPlayerExitEvacute);

        // 启动空窗期，防止从锚脱离时立即触发撤离
        cooldownRemaining = EvacuateCooldown;

        Oxygen.Instance.StartReduce();
    }

    private void OnPlayerEnterEvacuate()
    {
        // 空窗期内忽略进入事件
        if (cooldownRemaining > 0f) return;

        isInEvacuateZone = true;
        EventBus.Instance.AddListener(EventType.Interactive, OnPlayerEvacuate);
        UIManager.Instance.ShowUI<PlayerEvacuteText>();
    }

    private void OnPlayerExitEvacute()
    {
        isInEvacuateZone = false;
        EventBus.Instance.RemoveListener(EventType.Interactive, OnPlayerEvacuate);
        UIManager.Instance.HideUI<PlayerEvacuteText>();
    }

    private void OnPlayerEvacuate()
    {
        // 隐藏撤离提示UI
        UIManager.Instance.HideUI<PlayerEvacuteText>();
        EventBus.Instance.RemoveListener(EventType.Interactive, OnPlayerEvacuate);
        isInEvacuateZone = false;
        // 触发撤离事件
        EventBus.Instance.TriggerEvent(EventType.PlayerEvacuate);

        EventBus.Instance.TriggerEvent<BaseState>(EventType.ChangeState,new OnBoat());
        Debug.Log("玩家撤离");
    }

    public override void UpdateState()
    {
        if (cooldownRemaining > 0f)
        {
            cooldownRemaining -= Time.deltaTime;
            // 空窗期结束，检查玩家是否已在撤离区域内
            if (cooldownRemaining <= 0f && Evacuate.IsPlayerInZone)
            {
                OnPlayerEnterEvacuate();
            }
        }
    }

    public override void ExitState()
    {
        // 清理撤离区域监听
        EventBus.Instance.RemoveListener(EventType.PlayerEnterEvacuate, OnPlayerEnterEvacuate);
        EventBus.Instance.RemoveListener(EventType.PlayerExitEvacute, OnPlayerExitEvacute);

        // 如果在撤离区域内退出，清理交互监听和UI
        if (isInEvacuateZone)
        {
            EventBus.Instance.RemoveListener(EventType.Interactive, OnPlayerEvacuate);
            UIManager.Instance.HideUI<PlayerEvacuteText>();
            isInEvacuateZone = false;
        }

        cooldownRemaining = 0f;

        Oxygen.Instance.StopReduce();
    }
}
