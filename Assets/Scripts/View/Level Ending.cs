using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LevelEnding : MonoBehaviour
{
    [SerializeField] private Text _currentSocre;
    [SerializeField] private Text _highScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentSocre = GameObject.Find("CurrentScore").GetComponent<Text>();
        _highScore = GameObject.Find("HighScore").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.Alive || GameManager.Instance.CompleteLevel)
        {
            _currentSocre.text = DataManager.Instance.GetScore().ToString();
            _highScore.text = DataManager.Instance.GetHighScore().ToString();
        }
    }
}
