using Photon.Pun;
using UnityEngine;

public class NetworkCubeMaker : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject networkCube;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Cが押されました");
            PhotonNetwork.Instantiate(networkCube.name, new Vector3(1,10,1), Quaternion.identity, 0);
        }
    }
}