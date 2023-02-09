using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PhotonConnecter : MonoBehaviourPunCallbacks
{
    [SerializeField] private string gameVersion = "0.1";
    [SerializeField] private string nickName = "TestName";
    [SerializeField] private string roomName = "TestRoom";

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;//このように設定すると、MasterClient以外のClientがシーンの切り替えを、MasterClientのシーンの切り替えに同期して行うことができます。
        PhotonNetwork.GameVersion = gameVersion;//バージョンの異なるClient同士はマッチングすることができないようにする
        PhotonNetwork.NickName = nickName;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Connect();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            JoinRoom();
        }
    }

    private void Connect()
    {
        Debug.Log("Photon Cloud に接続します。");
        PhotonNetwork.ConnectUsingSettings();//サーバーに接続する
    }

    private void JoinRoom()
    {
        Debug.Log($"{roomName}に参加します。");
        PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions(), TypedLobby.Default);
    }

    public override void OnConnectedToMaster()//サーバーに接続したときに呼ばれるコールバック関数
    {
        Debug.Log("Photon Cloud に接続しました。");
       // PhotonNetwork.JoinRandomRoom(); ルームがすでに作られている場合はルームに入る  コールバック関数はOnJoinRandomFailed（）
    }

    public override void OnJoinedRoom()
    {
        Debug.Log($"{roomName} に参加しました。");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"{newPlayer.NickName} が入室しました。");
    }
}