using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingleMono<InputManager>
{
    private bool isPlayerInputEnabled = true;
    private bool isBoatInputEnabled = false;
    private bool isAnchorInputEnabled = false;

    void Update()
    {
        OnInteractive();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        OnPlayerMove();
        OnAnchorMove();
        OnBoatMove();
        
    }

    /// <summary>启用玩家输入模式（玩家移动，船和锚不动）</summary>
    public void EnablePlayerInput()
    {
        isPlayerInputEnabled = true;
        isBoatInputEnabled = false;
        isAnchorInputEnabled = false;
    }

    /// <summary>启用船输入模式（船移动，玩家跟随，锚不动）</summary>
    public void EnableBoatInput()
    {
        isPlayerInputEnabled = false;
        isBoatInputEnabled = true;
        isAnchorInputEnabled = false;
    }

    /// <summary>启用锚输入模式（锚移动，玩家和船不动）</summary>
    public void EnableAnchorInput()
    {
        isPlayerInputEnabled = false;
        isBoatInputEnabled = false;
        isAnchorInputEnabled = true;
    }

    // 保持向后兼容
    public void EnableInput() => EnablePlayerInput();
    public void DisableInput() => EnableBoatInput();

    public void OnPlayerMove()
    {
        if(!isPlayerInputEnabled) return;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        EventBus.Instance.TriggerEvent(EventType.PlayerMove, new Vector2(horizontal, vertical));
    }

    public void OnAnchorMove()
    {
        if(!isAnchorInputEnabled) return;
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        EventBus.Instance.TriggerEvent(EventType.AnchorMove, scroll);
    }

    public void OnBoatMove()
    {
        if(!isBoatInputEnabled) return;
        float scroll = Input.GetAxis("Horizontal");
        EventBus.Instance.TriggerEvent(EventType.BoatMove, scroll);
    }
    public  void OnInteractive()
    {
        if(Input.GetKeyDown(KeyCode.F))
            EventBus.Instance.TriggerEvent(EventType.Interactive);
    }
}
