using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TANKU : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    private Rigidbody rb;
    private float movementInputValue;
    private float turnInputValue;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Turn();
    }

    // 前進・後退のメソッド
    void Move()
    {
        movementInputValue = Input.GetAxis("Vertical");
        Vector3 movement = movementInputValue * moveSpeed * transform.forward;
        rb.AddForceAtPosition(movement,this.transform.position);
    }

    // 旋回のメソッド
    void Turn()
    {
        turnInputValue = Input.GetAxis("Horizontal");
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}

