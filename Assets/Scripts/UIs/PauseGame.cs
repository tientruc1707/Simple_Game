using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : View
{
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _homeButton;
    public override void Initialize()
    {
        _resumeButton.onClick.AddListener(() => UIManager.ShowLast());
    }
}
