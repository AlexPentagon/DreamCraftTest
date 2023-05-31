using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action OnDead;
    public event Action OnDamaged;
    public bool isDead { get; private set; }
    public int MaxHealth { get => maxHealth; set => MaxHealth = MaxHealth; }
    public int CurrentHealth { get => currentHealth; set => CurrentHealth = CurrentHealth; }


    [SerializeField] int maxHealth;

    private int currentHealth;

    private void OnEnable()
    {
        currentHealth = maxHealth;
        isDead = false;
    }

    public void SubstructHealth(int amount)
    {
        if (amount < 0)
            throw new System.Exception("Trying substract negative amount from health");

        if (isDead)
            return;

        currentHealth -= amount;
        OnDamaged?.Invoke();
        if (currentHealth <= 0)
        {
            isDead = true;
            OnDead?.Invoke();
        }
    }
}
