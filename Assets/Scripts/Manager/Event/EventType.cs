using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
    /// <summary>
    /// float���Ͳ���
    /// </summary>
    AnchorMove,
    /// <summary>
    /// Vector2���Ͳ���PlayerMove
    /// </summary>
    PlayerMove,
    /// <summary>
    /// int���Ͳ���
    /// </summary>
    OnMoneyChange,
    /// <summary>
    /// int���Ͳ���
    /// </summary>
    OnOxygenChange,
    /// <summary>
    /// int���Ͳ���
    /// </summary>
    OnMaxOxygenChange,
    /// <summary>
    /// int���Ͳ���
    /// </summary>
    OnPlayerSpeedChange,
    /// <summary>
    /// int���Ͳ���
    /// </summary>
    OnMaxDeepChange,
    /// <summary>
    /// int类型参数
    /// </summary>
    OnCurrentDeepChange,
    /// <summary>
    /// �޲���
    /// </summary>
    OnPlayerDie,
    /// <summary>
    /// float���Ͳ���
    /// </summary>
    BoatMove,
    /// <summary>
    /// BaseEquip���Ͳ���
    /// </summary>
    OnPlayerEquipChange,
    /// <summary>
    /// bool���Ͳ���
    /// </summary>
    PlayerLightingChange,
    /// <summary>
    /// float���Ͳ���
    /// </summary>
    OxygenDeclineSpeed,
    /// <summary>
    /// int���Ͳ���
    /// </summary>
    OxygenChange,
    /// <summary>
    /// int���Ͳ���
    /// </summary>
    MaxOxygenChange,
    /// <summary>
    /// BaseState类型参数
    /// </summary>
    ChangeState,
    /// <summary>
    /// 无参，F交互键事件
    /// </summary>
    Interactive,
    /// <summary>
    /// 无参，停止船移动
    /// </summary>
    StopBoat,
    /// <summary>
    /// 无参，玩家进入撤离
    /// </summary>
    PlayerEnterEvacuate,
    /// <summary>
    /// 无参，玩家离开撤离区
    /// </summary>
    PlayerExitEvacute,
    /// <summary>
    /// 无参，玩家撤离
    /// </summary>
    PlayerEvacuate
    
}
