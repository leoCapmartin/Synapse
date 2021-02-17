using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using WebSocketSharp;

public class NetworkController : MonoBehaviourPunCallbacks
{
    public Text Info = null;
    public GameObject join;
    public GameObject joined;
    public InputField RoomCode = null;
    public byte MaxPlayers = 2;
    public string sceneName = "Level";//nom de la scene à load une fois la connection à la room effectué
    

    private void SetState(string info)
    {
        Info.text = info;
        Debug.Log(info);
    }

    private void ToggleEnveironement(bool state)
    {
        join.SetActive(state);
        joined.SetActive(!state);
    }
    public void Start()
    {
        if(!PhotonNetwork.InRoom)
        {
            PhotonNetwork.ConnectUsingSettings();
            joined.SetActive(false);
            join.SetActive(false);
            SetState("Connexion vers le serveur ...");
        }
        else
            ToggleEnveironement(false);
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.AutomaticallySyncScene = true;
        ToggleEnveironement(true);
        SetState("Connexion établie au serveur : " + PhotonNetwork.ServerAddress);
    }

    public void JoinButtonClick()
    {
        if(!PhotonNetwork.NickName.IsNullOrEmpty())
        {
            string roomName = RoomCode.text;
            PhotonNetwork.JoinRoom(roomName);
            ToggleEnveironement(false);
        }
        else
            SetState("Invalid Nickname (Nicknames must contain 4 characters or more).");
    }
    public void CreateButtonClick()
    {
        Debug.Log(PhotonNetwork.NickName);
        if(!PhotonNetwork.NickName.IsNullOrEmpty())
        {
            string room = "";
            for (int i = 0; i < 6; i++)
                room += (char) Random.Range(65, 91);

            RoomOptions options = new RoomOptions();
            options.IsOpen = true;
            options.IsVisible = true;
            options.MaxPlayers = MaxPlayers;

            PhotonNetwork.CreateRoom(room, options, TypedLobby.Default);

            ToggleEnveironement(false);

            SetState("Tente de rejoindre : " + room);
        }
        else
            SetState("Invalid Nickname (Nicknames must contain 4 characters or more).");
    }

    public override void OnJoinedRoom()
    {
        SetState("Has joined the room");
        base.OnJoinedRoom();
        //SceneManager.LoadScene("Level");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        SetState("cannot join room : " + message);
        base.OnJoinRoomFailed(returnCode, message);
    }
}