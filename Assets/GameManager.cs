using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab; //Inspector�ŕR�Â�

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            if (playerPrefab != null) //�������郂�m���R�Â����Ă��邩�m�F
            {
                int randomPoint = Random.Range(-20, 20); //2�̐��l�ԂŃ����_���Ȓl����
                PhotonNetwork.Instantiate("Player", new Vector3(randomPoint, 2, randomPoint), Quaternion.identity, 0); //y���W�̂�0�̉��Ńv���n�u�𐶐�
            }
        }
    }
}