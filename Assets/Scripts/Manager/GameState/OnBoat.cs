using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBoat : BaseState
{
    private Vector3 _offset = new Vector3(0,0f,0);
    private Transform playerTransform;
    private Transform boatTransform;
    private Rigidbody2D playerRb;

    public override void EnterState()
    {
        // 切换到船输入模式
        InputManager.Instance.DisableInput();

        // 玩家跟随船：找到玩家和船，将玩家设为船的子物体
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        B_move boat = GameObject.FindObjectOfType<B_move>();
        if (player != null && boat != null)
        {
            playerTransform = player.transform;
            boatTransform = boat.transform;
            playerRb = player.GetComponent<Rigidbody2D>();

            // 将玩家设置为船的子物体，跟随船移动
            playerTransform.SetParent(boatTransform,false);
            playerTransform.localPosition = _offset;
            if (playerRb != null)
            {
                // 设为Kinematic防止动态刚体与父物体物理冲突
                playerRb.isKinematic = true;
                playerRb.velocity = Vector2.zero;
            }
        }

        EventBus.Instance.AddListener(EventType.Interactive, OnInteractive);

        EventBus.Instance.TriggerEvent(EventType.OxygenChange,int.MaxValue);
    }

    private void OnInteractive()
    {
        // 按F键切换到锚点状态
        EventBus.Instance.TriggerEvent<BaseState>(EventType.ChangeState, new OnAnchor());
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {
        EventBus.Instance.RemoveListener(EventType.Interactive, OnInteractive);

        // 将玩家从船上分离
        if (playerTransform != null)
        {
            playerTransform.SetParent(null);
            if (playerRb != null)
            {
                // 恢复动态刚体，让玩家可以独立移动
                playerRb.isKinematic = false;
                playerRb.velocity = Vector2.zero;
            }
        }
    }
}
