using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalEvents : MonoBehaviourPunCallbacks
{
    public void QuitRoom()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Menu");
    }
    
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        QuitRoom();
        base.OnMasterClientSwitched(newMasterClient);
    }
}
