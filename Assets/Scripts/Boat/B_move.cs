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
        rb = GetComponent<Rigidbody2D>();
        EventBus.Instance.AddListener<float>(EventType.BoatMove, Move);
        EventBus.Instance.AddListener(EventType.StopBoat, StopBoat);
    }

    public void Move(float f)
    {
        vector2 = rb.velocity;
        vector2.x = f * B_speed;
        rb.velocity = vector2;
    }

    private void StopBoat()
    {
        rb.velocity = Vector2.zero;
    }

    private void OnDestroy()
    {
        EventBus.Instance.RemoveListener<float>(EventType.BoatMove, Move);
        EventBus.Instance.RemoveListener(EventType.StopBoat, StopBoat);
    }
}
