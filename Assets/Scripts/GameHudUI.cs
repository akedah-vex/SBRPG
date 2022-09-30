using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHudUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sessionTextUI;
    [SerializeField] private TextMeshProUGUI versionTextUI;

    private GameManager gameManager;

    private void Awake ()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start ()
    {
        RenderHudUIElements();
        
    }

    private void RenderHudUIElements()
    {
        RenderText();
    }

    private void RenderText ()
    {
        RenderSessionText();
        RenderVersionText();
    }

    private void RenderSessionText ()
    {
        if (!sessionTextUI) return;

        string sessionName = gameManager.GetSessionName();
        if (sessionName == null || sessionName == "")
        {
            sessionTextUI.text = "SESSION: No Session Name";
        }
        else
        {
            sessionTextUI.text = "SESSION: " + sessionName;
        }
    }

    private void RenderVersionText ()
    {
        if (!versionTextUI) return;

        string version = gameManager.GetVersion();
        if (version == null || version == "")
        {
            versionTextUI.text = "version: VERSION ERROR";
        }
        else
        {
            versionTextUI.text = "version: " + version;
        }
    }
}
