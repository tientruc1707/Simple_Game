using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private GameManager _gameManager;
    private DataManager _dataManager;

    private int _levelMaxUnlocked;
    public int levelToUnlock;
    void Start()
    {
        _gameManager = GameManager.Instance;
        _dataManager = DataManager.Instance;
        _levelMaxUnlocked = _dataManager.GetLevel();
    }
    void Update()
    {
        if (!_gameManager.Alive)
        {
            _dataManager.SetScore(_gameManager.Score);
            if (_gameManager.Score > _dataManager.GetHighScore())
            {
                _dataManager.SetHighScore(_gameManager.Score);
            }
        }
        if (_gameManager.CompleteLevel)
        {
            _dataManager.SetScore(_gameManager.Score);
            if (_gameManager.Score > _dataManager.GetHighScore())
            {
                _dataManager.SetHighScore(_gameManager.Score);
            }
            if (_levelMaxUnlocked < levelToUnlock)
            {
                _levelMaxUnlocked = levelToUnlock;
            }
            _dataManager.SetLevel(_levelMaxUnlocked);
        }
    }
}
