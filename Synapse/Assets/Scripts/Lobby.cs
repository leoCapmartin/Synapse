using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviourPunCallbacks
{
    public Text[] Player = new Text[2];
    public Text RoomCode;

    private void updatePlayerListUI()//pour afficher la liste des joueurs
    {
        int i = 0;
        foreach (var kvp in PhotonNetwork.CurrentRoom.Players)
        {
            Player[i].text = kvp.Value.NickName;
            i++;
        }
    }

    // Start is called before the first frame update
    public override void OnJoinedRoom()
    {
        RoomCode.text += PhotonNetwork.CurrentRoom.Name;
        updatePlayerListUI();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Player[1].text = newPlayer.NickName;
        base.OnPlayerEnteredRoom(newPlayer);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (otherPlayer.IsMasterClient)
        {
            Debug.Log("MasterClient left the room");
            QuitRoom();
        }
        else
        {
            Debug.Log("Normal player left the room");
            int i = 0;
            foreach (var kvp in PhotonNetwork.CurrentRoom.Players)
            {
                Player[i].text = kvp.Value.NickName;
                i++;
            }
        }
    }

    public void QuitRoom()
    {
        PhotonNetwork.LeaveRoom();
        //updatePlayerListUI();
        SceneManager.LoadScene("Menu");
    }
    public void StartGame()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            SceneManager.LoadScene("Level");
        }
    }
}
