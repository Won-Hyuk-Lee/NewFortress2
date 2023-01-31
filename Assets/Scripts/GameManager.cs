using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Button CreateRoomButton = null;
    [SerializeField] TMP_InputField RoomName = null;
    
    [SerializeField] TMP_InputField NickName = null;
    [HideInInspector] public string Rname;
    [HideInInspector] public string Nname;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        DontDestroyOnLoad(this);
    }

    public void OnClickCreateRoom()
    {
        OnInputChanged();
        PhotonNetwork.CreateRoom(Rname);
    }

    public void OnInputChanged()
    {
        if (RoomName.text.Length < 10 && RoomName.text.Length > 2)
        {
            Rname = RoomName.text;
        }
        else
        {
            Debug.Log("Id 길이가 틀립니다 2~9");
        }
    }

    public void JoinLobby()
    {
        PhotonNetwork.JoinLobby();
    }

    public void OnClick_Connect()
    {
        //if (string.IsNullOrEmpty(PhotonNetwork.NickName) == true)
        //return;
        PhotonNetwork.LocalPlayer.NickName = NickName.text;
        PhotonNetwork.JoinOrCreateRoom("myroom", new RoomOptions { MaxPlayers = 2 }, null);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Loading");

    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
                PhotonNetwork.LoadLevel("Ingame");
            }
        }
    }






}
