using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CodeMoveBulon : MonoBehaviour
{
    public float left, right;
    private bool isRight;

    // Update is called once per frame
    void Update()
    {
        var namX = transform.position.x;
        if(namX < left){
            isRight = true;
            LatNguoc(true);
        }
        if(namX > right ){
            isRight = false;
            LatNguoc(false);
        }
        if(isRight){
            transform.Translate(new Vector3(Time.deltaTime * 1, 0 ,0));
        }else{
            transform.Translate(new Vector3(-Time.deltaTime * 1, 0 ,0));
        }

    }

    void LatNguoc(bool lat){
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * (lat ? 1 : -1);
        transform.localScale = scale;
    }
}