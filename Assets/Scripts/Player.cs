using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using GameConstants;
using Photon.Pun;

public class Player : MonoBehaviour
{
    /// Serialized Fields
    [SerializeField] private float moveSpeed = 1.4f;

    private PhotonView photonView;

    /// Private member variables
    private Vector2 rawInput;
    private Vector2 minBounds;
    private Vector2 maxBounds;

    private void Start () 
    {
        // InitializeBoundaries();
        photonView = GetComponent<PhotonView>();
    }

    private void Update () 
    {
        CheckMovement();
    }

    private void OnMove (InputValue value) 
    {
        if (!photonView.IsMine) return;
        rawInput = value.Get<Vector2>();
        Debug.Log("OnMove: " + rawInput);
    }

    private void CheckMovement () 
    {
        if (!photonView.IsMine) return;
        // store current position
        float oldValue = transform.position.y;

        // get new position
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = transform.position.x + delta.x;
        newPos.y = transform.position.y + delta.y;
        transform.position = newPos;
    }

    private void InitializeBoundaries () 
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    public PhotonView NetworkView()
    {
        return photonView;
    }
}
