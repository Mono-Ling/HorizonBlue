using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorMove : MonoBehaviour
{
    public float moveSpeed = 70f;
    public Material material;
    private Vector2 startPos = Vector2.zero;
    private LineRenderer anchorLine;
    private bool _token = false;
    // Start is called before the first frame update
    void Start()
    {
        
        GameObject anchorLineObj = new GameObject("AnchorLine");
        anchorLineObj.transform.SetParent(this.transform);
        anchorLine = anchorLineObj.AddComponent<LineRenderer>();
        anchorLine.positionCount = 2;
        anchorLine.startWidth = 0.1f;
        anchorLine.endWidth = 0.1f;
        anchorLine.material = material;
        anchorLine.SetPosition(0, startPos);
        EventBus.Instance.AddListener<float>(EventType.AnchorMove, Move);
        EventBus.Instance.AddListener(EventType.PlayerEvacuate,UpdateStartPos);
    }

    private void Move(float dir)
    {
        if(!_token)
        {
            startPos = transform.position;
            anchorLine.SetPosition(0,startPos);
            _token = true;
        }
        transform.Translate(Vector2.up * dir * Time.deltaTime * moveSpeed);
        if(transform.position.y > startPos.y)
        {
            transform.position = startPos;
        }
        anchorLine.SetPosition(1, transform.position);
    }
    private void UpdateStartPos() 
    { 
        transform.position = startPos;
        anchorLine.SetPosition(0,Vector3.zero);
        anchorLine.SetPosition(1,Vector3.zero);
        _token = false;
    }
    private void OnDestroy()
    {
        EventBus.Instance.RemoveListener<float>(EventType.AnchorMove, Move);
        EventBus.Instance.RemoveListener(EventType.PlayerEvacuate,UpdateStartPos);
    }
}
