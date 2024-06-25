using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class P_Stat : ScriptableObject
{
    [SerializeField] private float moveSpeed;

    public float MoveSpeed
    {
        get { return moveSpeed; } 
    }
}
