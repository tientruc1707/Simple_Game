using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private GameManager _gameManager;
    private DataManager _dataManager;

    public int _levelMaxUnlocked;
    public int _currentLevel;
    void Start()
    {
        _gameManager = GameManager.Instance;
        _dataManager = DataManager.Instance;
        _levelMaxUnlocked = _dataManager.GetLevel();
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
    }
    void Update()
    {
        if (_levelMaxUnlocked < _currentLevel)
        {
            _levelMaxUnlocked = _currentLevel;
        }
        WinLevel();
        LoseLevel();
    }
    private void WinLevel()
    {
        if (_gameManager.CompleteLevel)
        {
            _dataManager.SetScore(_gameManager.Score);
            if (_gameManager.Score > _dataManager.GetHighScore())
            {
                _dataManager.SetHighScore(_gameManager.Score);
            }
        }
    }
    private void LoseLevel()
    {
        if (!_gameManager.Alive)
        {
            _dataManager.SetScore(_gameManager.Score);
            if (_gameManager.Score > _dataManager.GetHighScore())
            {
                _dataManager.SetHighScore(_gameManager.Score);
            }
        }
    }
}
