using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInputField : MonoBehaviour
{
    public void SetNickName(string value)
    {
        PhotonNetwork.NickName = value;
    }
}
