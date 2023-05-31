using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDeltaMove
{
    public event Action<GameObject, int> OnDead;
    public Vector2 deltaMove { get; private set; }

    private Transform player;
    private int poolIndex;

    private void Start()
    {
        GetComponent<Health>().OnDead += Die;
    }

    private void Update()
    {
        deltaMove = (player.position- transform.position).normalized;
    }

    public void SetPlayer(Transform player)
    {
        this.player = player;
    }

    public void SetPoolIndex(int index)
    {
        poolIndex = index;
    }

    public void Die()
    {
        OnDead?.Invoke(gameObject,poolIndex);
    }



}
