
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
    [SerializeField]
    PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();//[serialzeField]�ł͂��܂�������
        Debug.Log("��"+PV);
    }
    private void Start()
    {
        player = this.gameObject;
    }

    void Update()
    {
        if (PV.IsMine)
        {
            if (Input.GetKeyDown("space"))
            {
                GameObject ball = (GameObject)Instantiate(ballPrefab, transform.position, Quaternion.identity);
                Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
                ballRigidbody.AddForce(transform.forward * speed);
            }
        }
        else {
            Debug.Log("����Ώۂ�����܂���");  
        }

    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Tank" && collision.gameObject != player)
        {
            Debug.Log(collision);
            // �Փ˂�������I�u�W�F�N�g���폜����
            PhotonNetwork.Destroy(collision.gameObject);
        }

    
    }


}
