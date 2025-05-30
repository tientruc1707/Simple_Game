using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LevelEnding : MonoBehaviour
{
    [SerializeField] private Text _currentScore;
    [SerializeField] private Text _highScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        _currentScore = _currentScore.GetComponent<Text>();
        _highScore = _highScore.GetComponent<Text>();
        SetUpScore();
    }
    private void SetUpScore()
    {
        _currentScore.text = DataManager.Instance.GetScore().ToString();
        if (DataManager.Instance.GetScore() > DataManager.Instance.GetHighScore())
        {
            DataManager.Instance.SetHighScore(DataManager.Instance.GetScore());
        }
        _highScore.text = DataManager.Instance.GetHighScore().ToString();
    }
}
