using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//1. camera folow nv

public class CameraFolowPlayer : MonoBehaviour
{
    //1.1 mong muốn là camera folow nhân vật
    //1.2 mình cần biết nv mình đang đứng ở đâu thì camera mới theo được nên cần khai báo 1 game object sau đó add player vào để lấy vị trí của nó.
    public GameObject player;//1.3 nhân vật của mình
    public float start, end;//1.4 khai báo 2 biến để add điểm bắt đầu và kết thúc
    public float start1, end1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1.5 đầu tiên là lấy vị trí của người chơi chỉ quân tâm tới chục x
        var playerX = player.transform.position.x;
        //1.6 tiếp theo là lấy vị trí của camera và cập nhật cả x y z
        var playerY =player.transform.position.y;
        var camX = transform.position.x;
        var camY = transform.position.y;//0
        var camZ = transform.position.z;//-10
        
        //check điều kiênk
        if(playerX > start && playerX < end){
            camX = playerX;
            
        }else{
            if(playerX < start)
            {
                camX = start;
                
            }
            if(playerX >end)
            {
                camX = end;
                
            }
        } 


        if(playerY > start1 && playerY < end1){
            camY = playerY;
            
        }else{
            if(playerY < start1)
            {
                camY = start1;
                
            }
            if(playerY >end1)
            {
                camY = end1;
                
            }
        } 
        // có vị trí của cam rôif thì set lại cho camera
        transform.position = new Vector3(camX, camY, camZ);
    }
}