using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class GameController : MonoBehaviour
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
}