using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof(Animator)) ]
[RequireComponent (typeof(Rigidbody2D))]
public class P_Movement : MonoBehaviour
{
    [SerializeField] private P_Stat stat;

    private Animator anim;
    private Rigidbody2D rb;

    private void Start()
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
        int inputX = (int)Input.GetAxisRaw("Horizontal");                                   // Get keyboard input
        rb.velocity = new Vector3(inputX * stat.MoveSpeed, rb.velocity.y);        // Apply movement velocity
        anim.SetInteger("inputX", inputX);                                                           // Animation

        if (inputX < 0 && transform.localScale.x > 0)                                          // Flip/Rotate character
            Helper_FlipPlayer();
        else if (inputX > 0 && transform.localScale.x < 0)
            Helper_FlipPlayer();

    }
    private void Helper_FlipPlayer()
    {
        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
    }
}
