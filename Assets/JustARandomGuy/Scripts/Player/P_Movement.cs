using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(Animator)) ]
[RequireComponent (typeof(Rigidbody2D))]
public class P_Movement : MonoBehaviour
{
    [SerializeField] private P_Stat stat;
    [SerializeField] private GameObject shootPoint;
    [SerializeField] private GameObject projectile;

    private Animator anim;
    private Rigidbody2D rb;

    private int inputX, inputY;
    private bool isCanAttack, isCanShoot;
    private int attackPattern;
    private int jumpCount;
    private bool isTouchingGround;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        isCanAttack = true;
        isCanShoot = true;
    }
    private void FixedUpdate()
    {
        Walk();
        ResetJumpCount();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            isTouchingGround = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isTouchingGround = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * stat.GroundCheckDistance);
    }

    /* Movement Section *////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Walk()
    {
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

    /* Jump Section */////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Jump()
    {
        // print("1");
        if (jumpCount < 2)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(stat.JumpStrength * Vector2.up, ForceMode2D.Impulse);
            jumpCount++;
            anim.SetInteger("jumpCount", jumpCount);
        }
    }
    private void ResetJumpCount()
    {
        int layerMask = (1 << LayerMask.NameToLayer("Ground"));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, stat.GroundCheckDistance, layerMask);

        if (!isTouchingGround && hit.collider != null)
        {
            jumpCount = 0;
            anim.SetInteger("jumpCount", jumpCount);
        }
    }

    /* Attack Section */////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Attack()
    {
        if (isCanAttack && isCanShoot)
        {
            if (attackPattern == 0)                         // Punch
            {
                anim.SetTrigger("attack");
                attackPattern++;
            }
            else if (attackPattern == 1)                // Kick
            {
                anim.SetTrigger("kick");
                attackPattern--;
            }
            isCanAttack = false;
            Invoke("Helper_ResetAttack", stat.AttackDelay);
        }
    }

    private void Shoot()
    {
        if (isCanAttack && isCanShoot)
        {
            GameObject projectile = Instantiate(this.projectile, shootPoint.transform.position, shootPoint.transform.rotation);
            if (transform.localScale.x < 0)
            {
                Vector3 pScale = projectile.transform.localScale;
                projectile.transform.localScale = new Vector3(pScale.x * -1, pScale.y, pScale.z);
            }
            anim.SetTrigger("shoot");
            isCanShoot = false;
            Invoke("Helper_ResetAttack", stat.ShootDelay);
        }
    }

    private void Helper_ResetAttack()
    {
        isCanAttack = true;
        isCanShoot = true;
    }

    /* Input Handler Section *////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void OnMovement(InputValue input)
    {
        inputX = (int) input.Get<Vector2>().x;
        inputY = (int) input.Get<Vector2>().y;
    }
    private void OnPunch()
    {
        Attack();
    }
    private void OnShoot()
    {
        Shoot();
    }
    private void OnJump()
    {
        Jump();
    }
}
