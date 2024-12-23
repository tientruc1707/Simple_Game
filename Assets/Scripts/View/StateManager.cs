
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
            CheckGameState();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
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
        }
    }

    public void WinGame()
    {
        if (!_levelPass.activeSelf)
        {
            _levelPass.SetActive(true);
        }
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
