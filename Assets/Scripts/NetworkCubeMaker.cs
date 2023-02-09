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
            PhotonNetwork.Instantiate(networkCube.name, new Vector3(Random.Range(-50f,50f),15,Random.Range(-50f,50f)), Quaternion.identity, 0);
        }
    }
}