using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1. là nhân vật di chuyển

public class Player : MonoBehaviour
{
    public Animator animator;
    public bool isRight = true;

    public float jumpForce = 5f; // Lực nhảy của chim

    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bool isMoving = false; // Biến để kiểm tra xem nhân vật có đang di chuyển hay không

        // Xử lý di chuyển sang phải
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isRight = true;
            isMoving = true; // Nhân vật đang di chuyển
            animator.SetBool("isRunning", true);
            transform.Translate(Time.deltaTime * 5, 0, 0);

            // Đảm bảo nhân vật quay mặt về phía đúng
            Vector2 scale = transform.localScale;
            if (scale.x < 0) // Nếu nhân vật đang quay trái
            {
                scale.x *= -1; // Đảo ngược hướng quay mặt
            }
            transform.localScale = scale;
        }

        // Xử lý di chuyển sang trái
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isRight = false;
            isMoving = true; // Nhân vật đang di chuyển
            animator.SetBool("isRunning", true);
            transform.Translate(-Time.deltaTime * 5, 0, 0);

            // Đảm bảo nhân vật quay mặt về phía đúng
            Vector2 scale = transform.localScale;
            if (scale.x > 0) // Nếu nhân vật đang quay phải
            {
                scale.x *= -1; // Đảo ngược hướng quay mặt
            }
            transform.localScale = scale;
        }

        // Xử lý khi không di chuyển
        if (!isMoving)
        {
            animator.SetBool("isRunning", true); // Đặt lại isRunning về false khi không di chuyển
        }

        // Xử lý nhảy
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetMouseButtonDown(0))
        {
            if (isRight)
            {
                transform.Translate(Time.deltaTime * 3, Time.deltaTime * 15, 0);
                Vector2 scale = transform.localScale;
                if (scale.x < 0)
                {
                    scale.x *= -1;
                }
                transform.localScale = scale;
            }
            else
            {
                transform.Translate(-Time.deltaTime * 3, Time.deltaTime * 7, 0);
                Vector2 scale = transform.localScale;
                if (scale.x > 0)
                {
                    scale.x *= -1;
                }
                transform.localScale = scale;
            }
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
}
