using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
    /// <summary>
    /// float类型参数
    /// </summary>
    AnchorMove,
    /// <summary>
    /// Vector2类型参数
    /// </summary>
    PlayerMove,
    /// <summary>
    /// int类型参数
    /// </summary>
    OnMoneyChange,
    /// <summary>
    /// int类型参数
    /// </summary>
    OnOxygenChange,
    /// <summary>
    /// int类型参数
    /// </summary>
    OnPlayerSpeedChange,
    /// <summary>
    /// int类型参数
    /// </summary>
    OnMaxDeepChange,
    /// <summary>
    /// 无参数
    /// </summary>
    OnPlayerDie,
    /// <summary>
    /// float类型参数
    /// </summary>
    BoatMove,
    /// <summary>
    /// BaseEquip类型参数
    /// </summary>
    OnPlayerEquipChange,
    /// <summary>
    /// bool类型参数
    /// </summary>
    PlayerLightingChange,
    /// <summary>
    /// float类型参数
    /// </summary>
    OxygenDeclineSpeed,

}
