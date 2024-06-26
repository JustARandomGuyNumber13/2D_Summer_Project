using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class P_Stat : ScriptableObject
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpStrength;
    [SerializeField] private float groundCheckDistance;

    [Header("Combat")]
    [SerializeField] private float attackDelay;
    [SerializeField] private float shootDelay;
    

    public float GroundCheckDistance
    { 
        get {return groundCheckDistance;}
    }
    public float JumpStrength
    {
        get {return jumpStrength;}
    }
    public float ShootDelay
    { 
        get {return shootDelay;}
    }
    public float AttackDelay
    { 
        get {return attackDelay;}
    }
    public float MoveSpeed
    {
        get { return moveSpeed; } 
    }
}
