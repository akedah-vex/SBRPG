using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// Initiates Photons server connection
    /// </summary>
    private void Start ()
    {
        PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = "us";
        PhotonNetwork.ConnectUsingSettings();
    }

    /// <summary>
    /// The callback that executes on successful
    /// server connection.
    /// </summary>
    public override void OnConnectedToMaster ()
    {
        Debug.Log("Connected to Master");
        SceneManager.LoadScene("MainMenu");
    }
}
