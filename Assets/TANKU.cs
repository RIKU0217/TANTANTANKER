using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class TANKU : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    private Rigidbody rb;
    private float movementInputValue;
    private float turnInputValue;
    PhotonView PV;
    [SerializeField] private PhotonView PVBall;
    [SerializeField] private GameObject ballet;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(GetComponent<Rigidbody>());
        }
    }

    void Update()
    {
        if (PV.IsMine)
        {
            if (Input.GetKeyDown("space"))
            {
                PhotonNetwork.Instantiate(ballet.name, transform.position, Quaternion.identity,0);
            }
        }
        else {
            Debug.Log("����Ώۂ�����܂���");  
        }

    }

    private void FixedUpdate()
    {
        if (PV.IsMine)
        {
            Turn();
            Move();
        }else{
            
        }
    }

    // �O�i�E��ނ̃��\�b�h
    void Move()
    {
        movementInputValue = Input.GetAxis("Vertical");
        Vector3 movement = movementInputValue * moveSpeed * transform.forward;
        rb.AddForceAtPosition(movement, this.transform.position);
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
