using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public event Action<GameObject> OnProjectileFinished;

    [SerializeField] float speed;
    [SerializeField] int hitsBeforeFinish;
    [SerializeField] float range;
    [SerializeField] int damage;


    private int hitsLeft;
    private float startTime;
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        startTime = Time.time;
        hitsLeft = hitsBeforeFinish;
    }

    private void FixedUpdate()
    {
        var dir = new Vector2(transform.up.x, transform.up.y);
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);

        if (Time.frameCount % 10 == 0)
        {
            if((Time.time - startTime) * speed > range)
            {
                Finish();
            }
            
        }
    }

    private void Finish()
    {
        OnProjectileFinished?.Invoke(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var health = collision.gameObject.GetComponent<Health>();
            if (health.isDead)
                return;
            
            health.SubstructHealth(damage);
            hitsLeft--;

            if (hitsLeft == 0)
            {
                Finish();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
