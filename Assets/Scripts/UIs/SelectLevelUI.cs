using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevelUI : View
{
    [SerializeField] private Button _backButton;
    public override void Initialize()
    {
        _backButton.onClick.AddListener(() => UIManager.ShowLast());
    }
}
