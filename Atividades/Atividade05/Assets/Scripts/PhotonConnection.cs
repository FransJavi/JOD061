using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class PhotonConnection : MonoBehaviourPunCallbacks

{
    public Button button;

    public string gameVersion;

    public string roomName;

    public byte MaxPlayers = 4;
    public InputField inputField;
    void Start()
    {
         
    }

    public void OnClickConectar(){
        inputField.interactable = false;
        button.interactable = false;
    
    if(!PhotonNetwork.IsConnected)
    {
        
        Debug.Log("Conectando ao servidor..");
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.NickName = inputField.text;
        PhotonNetwork.ConnectUsingSettings();
        return;
    }

    PhotonNetwork.JoinRandomRoom();
    
    
}
    
public override void OnConnectedToMaster()
{
 Debug.Log("Conectado!");
 button.GetComponentInChildren<Text>().text = "Iniciar";
 button.interactable = true;
}

public override void OnJoinRandomFailed(short returnCode, string message){
    RoomOptions options = new RoomOptions();
    options.MaxPlayers = 4;
    PhotonNetwork.JoinOrCreateRoom("JOD061",options ,TypedLobby.Default);
}

public override void OnJoinedRoom(){
    Debug.Log(PhotonNetwork.NickName + "entrou na sala! ");
    PhotonNetwork.LoadLevel("GameScene");
    Debug.Log("Total de jogadores na sala " + PhotonNetwork.CurrentRoom.PlayerCount);
}
public override void OnCreatedRoom(){
    Debug.Log("Sala JOD061 Criada!");
    }


}
