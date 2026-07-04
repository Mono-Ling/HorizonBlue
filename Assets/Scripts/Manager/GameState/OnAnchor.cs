using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAnchor : BaseState
{
    private Transform playerTransform;
    private Rigidbody2D playerRb;
    private int frameDelay;

    public override void EnterState()
    {
        // 停止船移动
        EventBus.Instance.TriggerEvent(EventType.StopBoat);
        // 切换到锚输入模式（锚可移动，玩家和船不可移动）
        InputManager.Instance.EnableAnchorInput();

        // 将玩家设为锚的子对象，跟随锚移动
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        AnchorMove anchor = GameObject.FindObjectOfType<AnchorMove>();
        if (player != null && anchor != null)
        {
            playerTransform = player.transform;
            playerRb = player.GetComponent<Rigidbody2D>();

            playerTransform.SetParent(anchor.transform);
            if (playerRb != null)
            {
                playerRb.isKinematic = true;
                playerRb.velocity = Vector2.zero;
            }
        }

        // 延迟一帧注册交互事件，防止同一帧F键跳过本状态
        frameDelay = 1;
    }

    private void OnInteractive()
    {
        // 按F键切换到游戏状态
        EventBus.Instance.TriggerEvent<BaseState>(EventType.ChangeState, new OnGame());
    }

    public override void UpdateState()
    {
        if (frameDelay > 0)
        {
            frameDelay--;
            if (frameDelay == 0)
            {
                EventBus.Instance.AddListener(EventType.Interactive, OnInteractive);
            }
        }
    }

    public override void ExitState()
    {
        EventBus.Instance.RemoveListener(EventType.Interactive, OnInteractive);

        // 将玩家从锚上分离
        if (playerTransform != null)
        {
            playerTransform.SetParent(null);
            if (playerRb != null)
            {
                playerRb.isKinematic = false;
                playerRb.velocity = Vector2.zero;
            }
        }

        // 恢复为船输入模式（由OnBoat.EnterState进一步接管）
        InputManager.Instance.EnableBoatInput();
    }
}
