using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingleMono<InputManager>
{
    private bool isInputEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        OnPlayerMove();
        OnAnchorMove();
    }
    public void EnableInput() => isInputEnabled = true;
    public void DisableInput() => isInputEnabled = false;
    public void OnPlayerMove()
    {
        if(!isInputEnabled) return;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        EventBus.Instance.TriggerEvent(EventType.PlayerMove, new Vector2(horizontal, vertical));
    }
    public void OnAnchorMove()
    {
        if(!isInputEnabled) return;
        float scroll = Input.GetAxis("Vertical");
        EventBus.Instance.TriggerEvent(EventType.AnchorMove, scroll);
    }
}
