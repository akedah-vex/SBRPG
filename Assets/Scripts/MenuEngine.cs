using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameConstants;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;


public class MenuEngine : MonoBehaviour
{

    #region Private Members

    /// <summary>
    /// The instanced singleton
    /// </summary>
    static private MenuEngine instance;

    /// <summary>
    /// The previous menu
    /// </summary>
    private string lastMenu;

    /// <summary>
    /// The current menu
    /// </summary>
    private string currentMenu;

    /// <summary>
    /// A reference to the game manager
    /// </summary>
    private GameManager gameManager;

    private AudioSource audioSource;

    private Slider volumeSlider;

    private TMP_Dropdown regionList;

    #endregion

    #region Unity Callbacks

    private void Awake ()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioSource = FindObjectOfType<AudioSource>();
    }

    // private void OnEnable() 
    // {
    //     SceneManager.sceneLoaded += OnSceneLoaded;
    // }

    // private void OnSceneLoaded (Scene scene, LoadSceneMode mode)
    // {
    //     PopulateRegionList();
    // }

    private void Start ()
    {
        volumeSlider = FindObjectOfType<Slider>();
        regionList = FindObjectOfType<TMP_Dropdown>();
        PopulateRegionList();

    }

    /// <summary>
    /// Unity Update Callback
    /// </summary>
    private void Update ()
    {
    }

    #endregion

    #region Public Methods

    public void PopulateRegionList()
    {
        if (SceneManager.GetActiveScene().name != Scenes.MAIN_MENU) return;

        string myRegion = PhotonNetwork.CloudRegion;
        string myRegionName = "";
        TMP_Dropdown.OptionData myRegionData = null;
        // populate list
        foreach ((string, string) region in ServerRegions.list)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
            data.text = region.Item2;

            if (region.Item1 == myRegion)
            {
                myRegionData = data;
                myRegionName = region.Item2;
            }

            regionList.options.Add(data);
        }
        // swap my region for spot 1 in the list
        foreach (TMP_Dropdown.OptionData data in regionList.options)
        {
            if (data.text == myRegionName)
            {
                regionList.options.Remove(data);
                break;
            }
        }
        if (myRegionData != null)
            regionList.options.Insert(0, myRegionData);
        regionList.RefreshShownValue();
    }

    /// <summary>
    /// Loads the Dev room joining scene
    /// from the main menu
    /// </summary>
    public void DevJoinMenu ()
    {
        gameManager.SetMenuActive(true);
        PhotonNetwork.LoadLevel(Scenes.DEV_JOIN_MENU);
    }

    public void BackToMainMenu ()
    {
        gameManager.SetMenuActive(true);
        PhotonNetwork.LoadLevel(Scenes.MAIN_MENU);
    }

    public void QuitApplication ()
    {
        Application.Quit();
    }

    public void AdjustVolume ()
    {
        audioSource.volume = volumeSlider.value;
    }

    public void ChangeRegion ()
    {
        if (!regionList) return;
        

        // get curr region selecetion from dropdown
        string selection = regionList.options[regionList.value].text;
        if (selection == null) return;

        // find matching string name in server regions list
        foreach ((string, string) region in ServerRegions.list)
        {
            if (selection == region.Item2)
            {
                Debug.Log("Connecting to: " + selection + " ...");
                PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = region.Item1;
                PhotonNetwork.Disconnect();
                if (PhotonNetwork.ConnectUsingSettings())
                {
                    Debug.Log("Connected!");
                }
            }
        }
    }

    #endregion
}
