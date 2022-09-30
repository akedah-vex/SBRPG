using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameConstants;

public class GameManager : MonoBehaviour
{

    #region Private Members

    private string version;

    /// <summary>
    /// The instanced singleton
    /// </summary>
    private static GameManager instance;
    
    /// <summary>
    /// True if the game is currently being played
    /// (IE not in main menus, active gameplay)
    /// </summary>
    private bool isRunning;
    
    /// <summary>
    /// True if a menu is currently active (pause / join menu)
    /// </summary>
    private bool menusActive;

    /// <summary>
    /// The name of the current game session
    /// </summary>
    private string sessionName;

    private string currentArea;

    private string previousArea;

    private AudioPlayer audioPlayer;

    private AudioSource audioSource;

    #endregion

    #region Unity Callbacks

    private void Awake ()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    
    /// <summary>
    /// Unity Start Callback
    /// </summary>
    private void Start ()
    {
        CreateSingleton();
        menusActive = true;
        previousArea = null;
        currentArea = null;
        version = "0.0.31";
    }

    private void Update ()
    {
        
    }

    #endregion
    
    #region Private Methods



    /// <summary>
    /// Initiates this class as a singleton
    /// </summary>
    private void CreateSingleton ()
    {
        if (instance !=null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    #endregion

    #region Public Methods

    public string GetVersion ()
    {
        return version;
    }

    /// <summary>
    /// Changes isRunning to true
    /// </summary>
    public void StartGame ()
    {
        isRunning = true;
    }

    /// <summary>
    /// Gets the value of isRunning
    /// </summary>
    /// <returns>bool isRunning</returns>
    public bool GetRunningState ()
    {
        return isRunning;
    }

    public bool IsMenuActive ()
    {
        return menusActive;
    }

    public void SetMenuActive (bool value)
    {
        menusActive = value;
    }

    public string GetSessionName ()
    {
        return sessionName;
    }

    public void SetSessionName (string name)
    {
        sessionName = name;
    }

    public string GetCurrentArea ()
    {
        return currentArea;
    }

    public void SetCurrentArea (string area)
    {
        Debug.Log("New Area: " + area + "\n" + "Prev Area: " + previousArea);
        previousArea = currentArea;
        currentArea = area;
    }

    #endregion
}
