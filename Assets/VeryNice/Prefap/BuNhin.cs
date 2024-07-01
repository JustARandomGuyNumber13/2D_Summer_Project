using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuNhin : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int mauToiDa;
    private int mauHienTai;
    Animator anim;
    [SerializeField] private float timeHs;
    private void Start(){
        mauHienTai = mauToiDa;
        anim = GetComponent<Animator>();
    }
    private void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            mauHienTai -= 1;
        }   

        if(mauHienTai <= 0){
            anim.SetBool("isDie",true);
            Invoke("HoiSinh",timeHs);
        }
        
    }
    private void HoiSinh(){
        anim.SetBool("isDie",false);
        mauHienTai = mauToiDa;
    }
}
