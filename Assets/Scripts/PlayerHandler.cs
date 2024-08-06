using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [Header("Data")]
    public float[] Positions;
    public int CurrentPositionIndex;
    public int platformReturningCount = 900;
    public float nextSpawnPoint = 300;

    [Header("PlayerData")]
    public GameObject player;
    public int speed = 2000;
    public bool IsGrounded;
    public float RayDistance;
    public LayerMask RayLayer;
    public float VerticalVelocity;
    public float Gravity;
    public Rigidbody Rb;
    public float JumpForce;
}
