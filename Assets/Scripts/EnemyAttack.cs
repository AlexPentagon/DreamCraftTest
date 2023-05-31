using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float secondsBetweentAttacks;

    private float lastAttackTime;
    private bool isTouchingPlayer;
    private Health playerHealth;

    private void Start()
    {
        isTouchingPlayer = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isTouchingPlayer = true;
            playerHealth = collision.gameObject.GetComponent<Health>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isTouchingPlayer = false;
            playerHealth = null;
        }
    }

    private void Update()
    {
        if (isTouchingPlayer)
        {
            if (lastAttackTime + secondsBetweentAttacks < Time.time)
            {
                playerHealth.SubstructHealth(damage);
                lastAttackTime = Time.time;
            }
        }
    }
}
