using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : View
{
    [SerializeField] private Button _settingButton;
    [SerializeField] private Button _trophyButton;
    //[SerializeField] private Button _quitButton;
    [SerializeField] private Button _play;
    public override void Initialize()
    {
        _settingButton.onClick.AddListener(() => UIManager.Show<SettingUI>());
        _trophyButton.onClick.AddListener(() => UIManager.Show<TrophyUI>());
        // _quitButton.onClick.AddListener(() => System.)
        _play.onClick.AddListener(() => UIManager.Show<SelectLevelUI>());
    }
}