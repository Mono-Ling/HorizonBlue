using UnityEngine;

public class Evacuate : MonoBehaviour
{
    /// <summary>玩家当前是否在撤离区域内</summary>
    public static bool IsPlayerInZone { get; private set; }

    [SerializeField]
    [Tooltip("撤离区域检测半径（单位与场景坐标一致）")]
    private float detectionRadius = 2f;

    private Transform playerTransform;
    private bool wasInZone;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    private void Update()
    {
        // 延迟查找玩家（可能尚未生成）
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerTransform = player.transform;
            }
            else
            {
                return;
            }
        }

        // 用坐标距离取模判定是否在撤离区域内
        float distance = Vector2.Distance(transform.position, playerTransform.position);
        bool isInZone = distance <= detectionRadius;

        if (isInZone && !wasInZone)
        {
            IsPlayerInZone = true;
            EventBus.Instance.TriggerEvent(EventType.PlayerEnterEvacuate);
        }
        else if (!isInZone && wasInZone)
        {
            IsPlayerInZone = false;
            EventBus.Instance.TriggerEvent(EventType.PlayerExitEvacute);
        }

        wasInZone = isInZone;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
#endif
}
