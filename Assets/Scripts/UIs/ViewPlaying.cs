using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ViewPlaying : View
{
    [SerializeField] private Button _pauseButton;

    public override void Initialize()
    {
        _pauseButton.onClick.AddListener(() => ViewManager.Open<ViewPauseGame>());
    }
    private void Pause()
    {
        Time.timeScale = 0;
    }
}
