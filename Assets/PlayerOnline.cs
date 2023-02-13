using UnityEngine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;


public class PlayerOnline : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    private Rigidbody rb;
    private float movementInputValue;
    private float turnInputValue;
    private GameObject childplayer;
    private PhotonView PV;
    [SerializeField] private PhotonView PVBall;
    [SerializeField] private GameObject ballet;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        childplayer = transform.GetChild(3).gameObject;
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
        if (PV.IsMine)
        {
            if (Input.GetKeyDown("space"))
            {
                PhotonNetwork.Instantiate(ballet.name, childplayer.transform.position, Quaternion.identity,0);
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
            Debug.Log("Turn()Move()");
        }
        else
        {
            Debug.Log("操作対象がありません");
        }
    }

    // 
    void Move()
    {
        movementInputValue = Input.GetAxis("Vertical");
        Vector3 movement = movementInputValue * moveSpeed * transform.forward;
        rb.AddForceAtPosition(movement, this.transform.position);
        Debug.Log(movementInputValue);
    }

    // 
    void Turn()
    {
        turnInputValue = Input.GetAxis("Horizontal");
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
