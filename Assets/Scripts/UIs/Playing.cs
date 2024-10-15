using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Playing : View
{
    [SerializeField] private Button _pauseButton;
    public override void Initialize()
    {
        _pauseButton.onClick.AddListener(() => UIManager.Open<PauseGame>());
    }
    public void Pause()
    {

    }
}
