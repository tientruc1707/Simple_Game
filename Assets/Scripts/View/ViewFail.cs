using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ViewFail : View
{
    [SerializeField] private Text _bestScore;
    [SerializeField] private Text _highScore;
    [SerializeField] private Button _homeButton;
    public override void Initialize()
    {
        _homeButton.onClick.AddListener(() => SceneManager.LoadScene(StringConstant.GameScene.MAINMENU));
    }
    void Update()
    {
        _highScore.text = "" + GameManager.Instance.Score;
        _bestScore.text = "" + DataManager.Instance.GetHighScore();
    }
}
