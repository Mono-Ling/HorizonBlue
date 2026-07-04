using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleMono<GameManager>
{
    private BaseState _currState = new OnBoat();
    // Start is called before the first frame update
    void Start()
    {
        EventBus.Instance.AddListener<BaseState>(EventType.ChangeState,ChangeState);
        _currState.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        _currState?.UpdateState();
    }
    private void ChangeState(BaseState state)
    {
        if(state == null) return;
        _currState?.ExitState();
        _currState = state;
        _currState.EnterState();
    }
    void OnDestroy()
    {
        EventBus.Instance.RemoveListener<BaseState>(EventType.ChangeState,ChangeState);
    }
}
