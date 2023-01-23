using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab; //Inspectorで紐づけ

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            if (playerPrefab != null) //生成するモノが紐づけられているか確認
            {
                int randomPoint = Random.Range(-20, 20); //2つの数値間でランダムな値を代入
                PhotonNetwork.Instantiate("Player", new Vector3(randomPoint, 2, randomPoint), Quaternion.identity, 0); //y座標のみ0の下でプレハブを生成
            }
        }
    }
}