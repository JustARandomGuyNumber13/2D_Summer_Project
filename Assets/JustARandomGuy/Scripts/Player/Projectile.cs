using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float projectileSpeed;
    private Rigidbody2D rb;
    private float direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        projectileSpeed = 10;
    }

    private void Start()
    {
        Invoke("SelfDestroy", 3f);
        direction = transform.localScale.x < 0 ? -1 : 1;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(projectileSpeed * direction, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SelfDestroy();
    }
    private void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
