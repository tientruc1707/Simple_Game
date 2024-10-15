using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState { Playing, Pause, GameOver }
    public GameState CurrentState { get; private set; }
    public int Score { get; private set; }
    public int CurrentLevel { get; private set; }
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PauseGame()
    {
        if (CurrentState == GameState.Playing)
        {
            CurrentState = GameState.Pause;
            Time.timeScale = 0;
        }
    }
    public void GameOver()
    {
        CurrentState = GameState.GameOver;
    }
    public void AddScore(int point)
    {
        Score += point;
    }
    public void LoadNextLevel()
    {
        CurrentLevel++;
        SceneManager.LoadScene("Level " + CurrentLevel.ToString());
    }
}
