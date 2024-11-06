using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewMainMenu : View
{
    [SerializeField] private Button _settingButton;
    [SerializeField] private Button _trophyButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _play;
    public override void Initialize()
    {
        _settingButton.onClick.AddListener(() => ViewManager.Show<ViewSetting>());
        _trophyButton.onClick.AddListener(() => ViewManager.Show<ViewTrophies>());
         _quitButton.onClick.AddListener(Application.Quit);
        _play.onClick.AddListener(() => ViewManager.Show<ViewSelectLevel>());
    }
}
