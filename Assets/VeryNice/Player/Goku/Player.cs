using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stat")]
    [SerializeField] private float moveSpeed;

    [Header("Run")]
    [SerializeField] private float run; [SerializeField] private float jump; [SerializeField] private float back;

    private Animator anim;
    private Rigidbody2D rb;

    private void Awake()
    {
        anim = GetComponent<Animator>();   
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float inputX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        rb.velocity = new Vector2(inputX, rb.velocity.y);

        anim.SetInteger("walk", (int) inputX);

        Vector3 scale = transform.localScale;
        if (inputX < 0 && scale.x > 0)              // Flip Left      Ctrl + K, C. U
            transform.localScale = new Vector2(-scale.x, scale.y);
        else if (inputX > 0 && scale.x < 0)      // Flip Right
            transform.localScale = new Vector2(-scale.x, scale.y);
    }
}
