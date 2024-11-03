using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewTrophies : View
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Text _bestScore;
    public override void Initialize()
    {
        _backButton.onClick.AddListener(() => ViewManager.ShowLast());
        _bestScore.text = "" + SaveData.Instance.GetHighScore();
    }
}
