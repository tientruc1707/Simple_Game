using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class MenuGame : MonoBehaviour
{

    public GameObject settingGUI;
    public GameObject menuGUI;
    public GameObject howToPlayGUI;
    public GameObject viewTrophyGUI;
    public GameObject selectLevelGUI;
    public void Start()
    {
        MenuOn();
        SoundManager.Instance.PlayBackgroundSound(StringConstant.SOUNDS.GAME_BACKGROUND);
    }
    public void PlayGame()
    {
        menuGUI.SetActive(false);
        selectLevelGUI.SetActive(true);
    }
    public void SettingOn()
    {
        menuGUI.SetActive(false);
        settingGUI.SetActive(true);
    }
    public void MenuOn()
    {
        settingGUI.SetActive(false);
        howToPlayGUI.SetActive(false);
        viewTrophyGUI.SetActive(false);
        selectLevelGUI.SetActive(false);
        menuGUI.SetActive(true);
    }

    public void HowToPlay()
    {
        howToPlayGUI.SetActive(true);
        menuGUI.SetActive(false);
    }
    public void ViewTroPhy()
    {
        viewTrophyGUI.SetActive(true);
        menuGUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

