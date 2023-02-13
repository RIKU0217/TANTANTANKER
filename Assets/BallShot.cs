
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class BallShot : MonoBehaviour
{
    private GameObject ballet;
    public float speed;

    [SerializeField] private PhotonView PV;
    [SerializeField] public GameObject player;

    private void Awake()
    {

        ballet = this.gameObject;
        PV = GetComponent<PhotonView>();//[serialzeField]�ł͂��܂�������
        Debug.Log(PV+"が確保されました");
        Debug.Log(ballet+"が確保されました");
    }

    void Update()
    {
        Rigidbody RbBallet = ballet.GetComponent<Rigidbody>();
        RbBallet.AddForce(PlayerOnline.childplayer.transform.forward * speed);
    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Tank" && collision.gameObject != player)
        {
            Debug.Log(collision);
            PhotonNetwork.Destroy(collision.gameObject);
        }

    
    }


}
