using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : KeepAttack
{
    public bool startStation;
    private bool _isActive;
    [Header("喷发与休息")]
    public float shootTime = 3f;
    public float restTime = 2f;
    [Header("子物体")]
    public ParticleSystem particleSystem;
    public BoxCollider2D boxCollider2D;
    public GameObject lightObj;
    public Animator animator;

    private float _timer;
    private void Start()
    {
        StartCoroutine(ShootIEnum());
    }
    private IEnumerator ShootIEnum()
    {
        while (true)
        {
            ShootOrRest(startStation);
            yield return new WaitForSeconds(shootTime);
            ShootOrRest(!startStation);
            yield return new WaitForSeconds(restTime);
        }
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    private void ShootOrRest(bool active)
    {
        _isActive = active;
        if (active)
        {
            particleSystem.Play();
            boxCollider2D.enabled = true;
        }
        else
        {
            particleSystem.Stop();
            boxCollider2D.enabled = false;
        }
        animator.SetBool("isActive", active);
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _isActive)
        {
            EventBus.Instance.TriggerEvent(EventType.OxygenDeclineSpeed, damageMultiplier);
        }
    }
}
