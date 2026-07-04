using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 startPos;
    private LineRenderer anchorLine;
    // Start is called before the first frame update
    void Start()
    {
        InputManager.Instance.EnableInput();
        startPos = transform.position;
        GameObject anchorLineObj = new GameObject("AnchorLine");
        anchorLineObj.transform.SetParent(this.transform);
        anchorLine = anchorLineObj.AddComponent<LineRenderer>();
        anchorLine.positionCount = 2;
        anchorLine.startWidth = 0.1f;
        anchorLine.endWidth = 0.1f;
        anchorLine.SetPosition(0, startPos);
        EventBus.Instance.AddListener<float>(EventType.AnchorMove, Move);
    }

    private void Move(float dir)
    {
        transform.Translate(Vector2.up * dir * Time.deltaTime * moveSpeed);
        if(transform.position.y > startPos.y)
        {
            transform.position = startPos;
        }
        anchorLine.SetPosition(1, transform.position);
    }
    private void OnDestroy()
    {
        EventBus.Instance.RemoveListener<float>(EventType.AnchorMove, Move);
    }
}
