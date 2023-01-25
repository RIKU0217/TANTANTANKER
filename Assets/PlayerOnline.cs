﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerOnline : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    private Rigidbody rb;
    private float movementInputValue;
    private float turnInputValue;
    [SerializeField]
    PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        Debug.Log("本体"+PV);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log(rb);

        if (!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(GetComponent<Rigidbody>());
        }
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (PV.IsMine)
        {
            Turn();
            Move();
            Debug.Log("Turn()Move()");
        }
        else
        {
            Debug.Log("操作対象がありません");
        }
    }

    // �O�i�E��ނ̃��\�b�h
    void Move()
    {
        movementInputValue = Input.GetAxis("Vertical");
        Vector3 movement = movementInputValue * moveSpeed * transform.forward;
        rb.AddForceAtPosition(movement, this.transform.position);
        Debug.Log(movementInputValue);
    }

    // ����̃��\�b�h
    void Turn()
    {
        turnInputValue = Input.GetAxis("Horizontal");
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
