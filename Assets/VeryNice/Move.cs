using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1. là nhân vật di chuyển

public class Move : MonoBehaviour
{


    //1.1 được quản lý bởi animater nên phải gọi animater ra và đặt tên cho nó và lấy ra toàn bộ settup 
    public Animator animator;
    //1.15 khai báo biến tiếp 
    public bool isRight = true;

    public float jumpForce = 5f; // Lực nhảy của chim

    private Rigidbody2D rb;


    void Start()
    {
        //1.2 lấy biến vừa tạo là animator sau đó dùng getcompoment để gọi các thành phần là Animator
        animator = GetComponent<Animator>();
                rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
         // Di chuyển nhân vật sang phải
        // Cập nhật biến đếm thời gian
      

        // Di chuyển nhân vật sang phải với tốc độ hiện tại
        //1.3 sử lý chạy sang phải vs Rightarrow
        if(Input.GetKey(KeyCode.RightArrow)){
            //1.16
            isRight = true;
            //1.4 bật animation di chuyển lên 
            animator.SetBool("isRunning", true);
            //1.5 khi di chuyển trục x sẽ thay đổi lên dương là tăng dần í 
            //1.6 bắt đầu sẽ gọi transform vì nó là nơi quản lý posison vì chỉ x thay đổi nên set cứng 1 số cho nó 
            //1.7 (x,y,z)
            //1.8 khi set cứng nó sẽ di chuyển quá nhanh nên phải sử dụng Time.deltatime là 1 biến chạy từ 0 đến 1
            //1.9 cái số được nhân nó sẽ quyết định khoảng cách 
            transform.Translate(Time.deltaTime * 5,0,0);

            Vector2 scale = transform.localScale;
            if(scale.x > 0){
                scale.x = scale.x *1;
            }else{
                scale.x = scale.x *-1;
            }
            transform.localScale = scale;

        }
        //1.10 di chuyển sang trái thì tương tự thay đổi lại là -deltatime và leftArrow
        if(Input.GetKey(KeyCode.LeftArrow)){
            //1.17
            isRight = false;
            animator.SetBool("isRunning", true);
            transform.Translate(-Time.deltaTime * 5,0,0);
            //1.11 vấn đề mắc phải là khi di chuyển trái thì nhân vật không quay mặt lại
        //1.12 nên phải set scale là về - ở position
        Vector2 scale = transform.localScale;
            if(scale.x > 0){
                scale.x = scale.x *-1;
            }else{
                scale.x = scale.x *1;
            }
            transform.localScale = scale;
            //1.13 bên trên làm tương tự 
        }

        //1.14 xử lý NHẢY khi nhảy trục x và y để thay đổi khi nhảy thì nhân vật sẽ nhảy 2 hướng để
        // biết được nhân vật đang bên nào thì cần khai báo cho nó 1 cái biết nhận biết.
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetMouseButtonDown(0)){
            if(isRight){
                transform.Translate(Time.deltaTime *3, Time.deltaTime*15, 0);
                Vector2 scale = transform.localScale;
            if(scale.x > 0){
                scale.x = scale.x *1;
            }else{
                scale.x = scale.x *-1;
            }
            transform.localScale = scale;
            }else{
                //1.18 nhảy ngược lại 
                transform.Translate(-Time.deltaTime *3, Time.deltaTime*7, 0);
                Vector2 scale = transform.localScale;
            if(scale.x > 0){
                scale.x = scale.x *-1;
            }else{
                scale.x = scale.x *1;
            }
            transform.localScale = scale;
            }
                        Jump();

        }
        void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
    }
}