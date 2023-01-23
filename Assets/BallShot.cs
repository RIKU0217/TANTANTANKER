
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class BallShot : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject player;
    public float speed;
    PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    private void Start()
    {
        player = this.gameObject;
    }

    void Update()
    {
        if (!PV.IsMine)
        {
            if (Input.GetKeyDown("space"))
            {
                GameObject ball = (GameObject)Instantiate(ballPrefab, transform.position, Quaternion.identity);
                Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
                ballRigidbody.AddForce(transform.forward * speed);
            }
        }
    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Tank" && collision.gameObject != player)
        {
            Debug.Log("�Փ�");
            // �Փ˂�������I�u�W�F�N�g���폜����
            PhotonNetwork.Destroy(collision.gameObject);
        }

    
    }


}
