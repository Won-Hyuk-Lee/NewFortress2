using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Spawner : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform masterTransform;
    [SerializeField] Transform otherTransform;

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        if(PhotonNetwork.IsMasterClient == true)
        {
            GameObject instTank = PhotonNetwork.Instantiate("tank", masterTransform.position,Quaternion.identity);
        }

        else
        {
            GameObject instTank = PhotonNetwork.Instantiate("tank", otherTransform.position, Quaternion.identity);
        }

    }

}
