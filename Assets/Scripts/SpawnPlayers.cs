using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void Start ()
    {
        Vector2 spawnPosition = new Vector2(0, 0);
        PhotonNetwork.Instantiate (
            player.name,
            spawnPosition, 
            Quaternion.identity
        );
    }
}
