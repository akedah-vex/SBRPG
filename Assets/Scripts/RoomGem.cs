using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using GameConstants;


public class RoomGem : MonoBehaviourPunCallbacks
{
    #region Private Members

    [Header("Input")]
    /// <summary>
    /// The text input field for room codes
    /// </summary>
    [SerializeField] private TMP_InputField inputField;

    /// <summary>
    /// The max number of players per session
    /// </summary>
    private const int maxPlayers = 4;

    /// <summary>
    /// The Menu Engine
    /// </summary>
    private MenuEngine menus;

    /// <summary>
    /// A reference to the join room menu
    /// </summary>
    private JoinRoomMenu joinRoomMenu;

    /// <summary>
    /// A reference to the game manager
    /// </summary>
    private GameManager gameManager;

    private AudioPlayer audioPlayer;

    #endregion

    #region Unity Callbacks

    /// <summary>
    /// Unity Awake Callback
    /// </summary>
    private void Awake ()
    {
        menus = FindObjectOfType<MenuEngine>();
        joinRoomMenu = FindObjectOfType<JoinRoomMenu>();
        gameManager = FindObjectOfType<GameManager>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// The public connect method,
    /// initiates CreateAndConnect flow
    /// </summary>
    public void Connect ()
    {
        CreateAndConnectToRoom();
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Sets room options and creates a room instance
    /// This will trigger OnJoinedRoom callback
    /// </summary>
    private void CreateAndConnectToRoom ()
    {   
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxPlayers;
        PhotonNetwork.CreateRoom(inputField.text, roomOptions);
    }

    /// <summary>
    /// Joins a room with given input
    /// Triggers OnJoinedRoom callback
    /// </summary>
    private void ConnectToRoom ()
    {
        PhotonNetwork.JoinRoom(inputField.text);
    }

    /// <summary>
    /// Prints an error code
    /// </summary>
    /// <param name="returnCode">the error return code</param>
    /// <param name="message">the error message</param>
    private void ErrorCode (short returnCode, string message)
    {
        Debug.Log(
            "Failed to create room\n" +
            "Return Code: " + returnCode + "\n" +
            "> " + message + "\n"
        );
    }

    #endregion

    #region Public Photon Callbacks

    /// <summary>
    /// Callback
    /// Gets called when a room is joined
    /// </summary>
    public override void OnJoinedRoom ()
    {
        Debug.Log("Joined Room!");
        gameManager.SetMenuActive(false);
        gameManager.SetSessionName(inputField.text);
        if (audioPlayer.IsMusicPlaying())
        {
            audioPlayer.Stop();
        }
        PhotonNetwork.LoadLevel(Scenes.GAME);
    }

    /// <summary>
    /// Callback
    /// Called when CreateAndConnectToRoom (CreateRoom) fails
    /// </summary>
    /// <param name="returnCode"></param>
    /// <param name="message"></param>
    public override void OnCreateRoomFailed (short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        ErrorCode(returnCode, message);
        Debug.Log("Attempting to connect to existing room");
        ConnectToRoom();
    }

    /// <summary>
    /// Callback
    /// Called when ConnectToRoom (JoinRoom) fails
    /// </summary>
    /// <param name="returnCode">the error return code</param>
    /// <param name="message">the error return message</param>
    public override void OnJoinRoomFailed (short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        ErrorCode(returnCode, message);
    }

    #endregion

}
