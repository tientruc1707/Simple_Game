using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewFail : View
{
    [SerializeField] private Text _bestScore;
    [SerializeField] private Text _highScore;
    [SerializeField] private Button _homeButton;
    public override void Initialize()
    {
        _homeButton.onClick.AddListener(() => ViewManager.Show<ViewMainMenu>());
    }
    void Start()
    {
        _highScore.text = "" + GameManager.Instance.Score;
        _bestScore.text = "" + SaveData.Instance.GetHighScore();
    }
}
