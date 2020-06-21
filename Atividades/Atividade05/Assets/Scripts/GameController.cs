using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameController : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickSair()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        Debug.Log(PhotonNetwork.NickName + "saiu na sala! ");
        //Debug.Log("Total de jogadores na sala " + PhotonNetwork.CurrentRoom.PlayerCount);
        PhotonNetwork.Disconnect();
    }

public override void OnDisconnected(DisconnectCause cause){
    Debug.Log("Desconectado!");
    PhotonNetwork.LoadLevel("LobbyScene");
}

}   

