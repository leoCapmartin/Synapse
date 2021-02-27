using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviourPunCallbacks
{
    
    public Transform[] SpawnPoint = new Transform[2];
    public Text RoomName;
    void Start()
    {
        int playerID = PhotonNetwork.LocalPlayer.ActorNumber;
        Dictionary<int, Player> players =  PhotonNetwork.CurrentRoom.Players;

        players[playerID].TagObject = PhotonNetwork.Instantiate("Player", SpawnPoint[playerID-1].position, SpawnPoint[playerID-1].rotation);
        RoomName.text += PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        SceneManager.LoadScene("Menu");
        base.OnPlayerLeftRoom(otherPlayer);
    }
}