
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    [SerializeField] private GameObject _levelPlay;
    [SerializeField] private GameObject _levelFail;
    [SerializeField] private GameObject _levelPass;
    [SerializeField] private GameObject _levelPause;
    public Text Score1, BestScore1, Score2, BestScore2;
    public int levelToUnlock;
    private int levelMaxUnlocked;
    private GameManager gameManager;



    void Start()
    {
        SettingScene();
        gameManager = GameManager.Instance;
        gameManager.ResetGame();
        UIManager.Instance.InitializeUI();
    }
    private void SettingScene()
    {
        Time.timeScale = 1;
        _levelPlay.SetActive(true);
        _levelPass.SetActive(false);
        _levelFail.SetActive(false);
        _levelPause.SetActive(false);
    }

    private void Update()
    {
        if (gameManager != null)
        {
            UpdateScore();
            CheckGameState();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    private void UpdateScore()
    {
        Score1.text = Score2.text = "" + GameManager.Instance.Score;
        BestScore1.text = BestScore2.text = "" + DataManager.Instance.GetHighScore();
    }

    private void CheckGameState()
    {
        if (!gameManager.Alive)
        {
            LoseGame();
        }

        if (gameManager.CompleteLevel)
        {
            WinGame();
        }
    }

    public void LoseGame()
    {
        Time.timeScale = 0f;
        if (!_levelFail.activeSelf)
        {
            _levelFail.SetActive(true);
            Score2.gameObject.SetActive(true);
            BestScore2.gameObject.SetActive(true);
        }
    }

    public void WinGame()
    {
        if (!_levelPass.activeSelf)
        {
            _levelPass.SetActive(true);
            Score1.gameObject.SetActive(true);
            BestScore1.gameObject.SetActive(true);
        }

        if (levelMaxUnlocked < levelToUnlock)
        {
            levelMaxUnlocked = levelToUnlock;
        }

        PlayerPrefs.SetInt("levelReached", levelMaxUnlocked);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        if (!_levelPause.activeSelf)
        {
            _levelPause.SetActive(true);
            _levelPlay.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            _levelPause.SetActive(false);
            _levelPlay.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(StringConstant.GameScene.MAINMENU);
    }

    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("No next level available.");
        }
    }
}
