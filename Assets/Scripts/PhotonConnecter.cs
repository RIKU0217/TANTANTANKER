using Photon.Pun;
using Photon.Realtime;//Playerクラス？が使えない
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

    public override void OnConnectedToMaster()//サーバーに接続したときに呼ばれるコールバック関数
    {
        Debug.Log("Photon Cloud に接続しました。");
    }

    private void JoinRoom()
    {
        Debug.Log($"{roomName}に参加します。");
        PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions(), TypedLobby.Default);//"roomname"という名前のルームに参加する。なければ作成して参加する
    }

    public override void OnJoinedRoom()//JoinorCreatRoom()が新規、既存のルームに参加することができた時呼ばれるコールバック関数
    {
        Debug.Log($"{roomName} に参加しました。");
    }
/*ここ二つのコールバック関数はエラーで使えなった
    public override void OnCreateRoom()//JoinorCreatRoom()で新規でルームを作成して参加したときのコールバック関数
    {
        Debug.Log($"{roomName} を作成しました");
    }

    public override void OnJoinRoomFailed()//JoinorCreatRoom()でルームに参加できなかったときのコールバック関数
    {
        Debug.Log($"{roomName} を参加または作成に失敗しました");
    }
*/
    public override void OnPlayerEnteredRoom(Player newPlayer)//ほかのPlayerが同じルームに入ってきたときに呼ばれるコールバック関数
    {
        Debug.Log($"{newPlayer.NickName} が入室しました。");
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)//ほかのPlayerが同じルームで出たときに呼ばれるコールバック関数
    {
        Debug.Log(otherPlayer+"が退出しました。ゲーム終了いたします");
    }
}