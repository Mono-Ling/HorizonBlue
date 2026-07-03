using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class P_move : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed = 1f;
    private Vector2 vec2;

    // Start is called before the first frame update
    private void Start()
    {
        InputManager.Instance.EnableInput();
        rb = GetComponent<Rigidbody2D>();
        EventBus.Instance.AddListener<Vector2>(EventType.PlayerMove,Move);
    }

    // Update is called once per frame

    public  void Move(Vector2 vector)
    {
        vec2 = vector;
        rb.velocity = vector * speed;

    }

    private void OnDestroy()
    {
        EventBus.Instance.RemoveListener<Vector2>(EventType.PlayerMove, Move);
    }
}


