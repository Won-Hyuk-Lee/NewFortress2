using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class LobbyControler : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text CurrentStatus = null;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentStatus.text = PhotonNetwork.NetworkClientState.ToString();
    }
}
