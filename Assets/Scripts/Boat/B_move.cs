using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_move : MonoBehaviour
{
    public float B_speed = 1f;
    private Rigidbody2D rb;
    private Vector2 vector2;

    private void Start()
    {
        InputManager.Instance.EnableInput();
        rb = GetComponent<Rigidbody2D>();
        EventBus.Instance.AddListener<Vector2>(EventType.PlayerMove, Move);

    }
    public void Move(Vector2 vector)
    {
        vector2 = rb.velocity; 
       vector2.x = vector.x * B_speed;
        rb.velocity = vector2;
    }

    private void OnDestroy()
    {
        EventBus.Instance.RemoveListener<Vector2>(EventType.PlayerMove,Move);
    }

}
