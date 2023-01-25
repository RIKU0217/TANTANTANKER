
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
        PV = GetComponent<PhotonView>();//[serialzeField]ではうまくいった
        Debug.Log("球"+PV);
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
            Debug.Log("操作対象がありません");  
        }

    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Tank" && collision.gameObject != player)
        {
            Debug.Log(collision);
            // 衝突した相手オブジェクトを削除する
            PhotonNetwork.Destroy(collision.gameObject);
        }

    
    }


}
