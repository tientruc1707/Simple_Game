using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameState gameState;

    public event System.Action<int> OnScoreChanged;
    public event System.Action<float> OnHealthChanged;
    public event System.Action OnGameOver;
    public event System.Action OnLevelComplete;

    public int Score
    {
        get => gameState.Score;
        private set
        {
            gameState.Score = Mathf.Max(0, value);
            OnScoreChanged?.Invoke(gameState.Score);
        }
    }

    public float Health
    {
        get => gameState.Health;
        private set
        {
            gameState.Health = Mathf.Clamp(value, 0, StringConstant.PlayerDetail.HEALTH);
            OnHealthChanged?.Invoke(gameState.Health);

            if (gameState.Health <= 0 && gameState.Alive)
            {
                gameState.Alive = false;
                OnGameOver?.Invoke();
            }
        }
    }

    public bool PlayerAttack
    {
        get => gameState.PlayerAttack;
        set => gameState.PlayerAttack = value;
    }

    public bool Alive
    {
        get => gameState.Alive;
        private set => gameState.Alive = value;
    }

    public bool CompleteLevel
    {
        get => gameState.CompleteLevel;
        set
        {
            gameState.CompleteLevel = value;
            if (value) OnLevelComplete?.Invoke();
        }
    }

    private void Awake()
    {
        InitializeSingleton();
    }

    private void InitializeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            ResetGame();
            Debug.Log($"Game restarted - Alive: {Alive}, Complete: {CompleteLevel}, Score: {Score}, Health:  {Health}");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetGame()
    {
        gameState = new GameState
        {
            Alive = true,
            Score = 0,
            Health = StringConstant.PlayerDetail.HEALTH,
            CompleteLevel = false,
            PlayerAttack = false
        };
        OnScoreChanged?.Invoke(Score);
        OnHealthChanged?.Invoke(Health);
    }

    public void HealthRegen()
    {
        Health = StringConstant.PlayerDetail.HEALTH;
    }

    public void UpdateScore(int points)
    {
        if (points != 0)
            Score += points;
        UIManager.Instance.UpdateScore(20);
    }

    public void UpdateHealth(float damage)
    {
        if (damage != 0)
            Health -= damage;
        UIManager.Instance.UpdateHealth(Health, StringConstant.PlayerDetail.HEALTH);
    }
}

// Tách riêng struct để lưu trữ game state
[System.Serializable]
public struct GameState
{
    public int Score;
    public float Health;
    public bool PlayerAttack;
    public bool Alive;
    public bool CompleteLevel;
}