using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour
{
   public GameObject projetilPrefab;
   public Transform projetilPosition;
    void Start()
    {
        Material material = GetComponent<Renderer>().material;
        material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    
    void Update()
    {
      

        if(!isLocalPlayer)
        {
            return;
        }
        transform.Translate(0f,0f,Input.GetAxis("Vertical")*0.1f);
        transform.Rotate(0f, Input.GetAxis("Horizontal")*10f,0f);
        if(Input.GetKeyUp(KeyCode.Space)){
            CmdAtirar();
        }
        }
        [Command]
        void CmdAtirar(){
            GameObject projetil = Instantiate(projetilPrefab,projetilPosition.position, transform.rotation);
            NetworkServer.Spawn(projetil);
}
}
