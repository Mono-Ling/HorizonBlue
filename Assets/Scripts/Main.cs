using UnityEngine;

/// <summary>
/// 游戏入口：在游戏启动时预热所有单例，确保初始化顺序正确。
/// 挂载到启动场景的任意 GameObject 上，并设置 Script Execution Order 为 -100 以确保最先执行。
/// </summary>
public class Main : MonoBehaviour
{
    [SerializeField] private bool _preWarmOnAwake = true;

    private void Awake()
    {
        if (_preWarmOnAwake)
        {
            PreWarmSingletons();
        }
    }

    /// <summary>
    /// 按依赖顺序预热所有单例，避免首次访问时的帧率尖峰。
    /// </summary>
    public void PreWarmSingletons()
    {
        // 第1层：事件系统（无依赖，其他管理器初始化时依赖它）
        var eventBus = EventBus.Instance;

        // 第2层：全局配置（GlobalValue 的 Set 方法会触发事件，需要 EventBus 就绪）
        var globalValue = GlobalValue.Instance;

        // 第3层：输入管理（B_move 等组件 Start 时会调用 InputManager）
        var inputManager = InputManager.Instance;

        // 第4层：游戏状态管理
        var gameManager = GameManager.Instance;

        // 第5层：玩法系统
        var oxygen = Oxygen.Instance;
        var playerEquip = PlayerEquip.Instance;

        // 第6层：音频（无依赖，最后预热）
        var audioManager = AudioManager.Instance;

        // 第7层：UI（加载 UICanvas，IO 操作较重，放最后）
        var uiManager = UIManager.Instance;

        AudioManager.Instance.Init();

        UIManager.Instance.ShowUI<DeepGauge>();

        UIManager.Instance.ShowUI<OxygenGauge>();

        UIManager.Instance.ShowUI<MemonyPanel>();

        GlobalValue.Instance.AddMoney(4);

#if UNITY_EDITOR
        Debug.Log($"[Main] 单例预热完成：" +
                  $"EventBus ✓, GlobalValue ✓, InputManager ✓, " +
                  $"GameManager ✓, Oxygen ✓, PlayerEquip ✓, " +
                  $"AudioManager ✓, UIManager ✓");
#endif
    }
}
