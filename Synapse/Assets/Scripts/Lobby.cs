using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviourPunCallbacks
{
    public GlobalEvents ge;
    public Text[] Player = new Text[2];
    public Text RoomCode;

    public void UpdatePlayerListUI() //pour afficher la liste des joueurs
    {
        int i = 0;
        Player[0].text = "";
        Player[1].text = "";
        foreach (var kvp in PhotonNetwork.CurrentRoom.Players)
        {
            Player[i].text = kvp.Value.NickName;
            i++;
        }
    }
    public override void OnJoinedRoom()
    {
        RoomCode.text += PhotonNetwork.CurrentRoom.Name;
        UpdatePlayerListUI();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerListUI();
        base.OnPlayerEnteredRoom(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerListUI();
        base.OnPlayerLeftRoom(otherPlayer);
    }

    public void StartGame()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            SceneManager.LoadScene("Level");
        }
    }
}
