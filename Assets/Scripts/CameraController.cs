using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;

public class CameraController : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera camera;
    private Player player;


    private void Awake ()
    {
        camera = FindObjectOfType<CinemachineVirtualCamera>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player) player = FindObjectOfType<Player>();
        if (!camera) camera = FindObjectOfType<CinemachineVirtualCamera>();

        if (camera && player.NetworkView().IsMine)
            camera.Follow = player.transform;
    }
}
