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
    // Start is called before the first frame update
    public override void OnJoinedRoom()
    {
        RoomCode.text += PhotonNetwork.CurrentRoom.Name;
        int i = 0;
        foreach (var kvp  in PhotonNetwork.CurrentRoom.Players)
        {
            Player[i].text = kvp.Value.NickName;
            i++;
        }   
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
            Debug.Log("test1");
            QuitRoom();
        }
        else
        {
            Debug.Log("test2");
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
        SceneManager.LoadScene("Menu");
    }
    public void StartGame()
    {
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            SceneManager.LoadScene("Level");
        }
    }
}
