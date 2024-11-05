using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ViewPass : View
{
    [SerializeField] private Text _bestScore;
    [SerializeField] private Text _highScore;
    [SerializeField] private Button _nextLevelButton;
    public override void Initialize()
    {
        _nextLevelButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }
    void Update()
    {
        _highScore.text = "" + GameManager.Instance.Score;
        _bestScore.text = "" + SaveData.Instance.GetHighScore();
    }
}
