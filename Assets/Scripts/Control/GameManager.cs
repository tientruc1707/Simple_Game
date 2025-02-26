using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
            Score = DataManager.Instance.GetScore(),
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
        UIManager.Instance.UpdateScore(Score);
    }

    public void UpdateHealth(float damage)
    {
        if (damage != 0)
            Health -= damage;
        UIManager.Instance.UpdateHealth(Health, StringConstant.PlayerDetail.HEALTH);
    }
    public void ShowDamageNumber(GameObject damageNumberPrefab, Vector3 worldPosition, float damage)
    {
        GameObject damageText = Instantiate(damageNumberPrefab, worldPosition, Quaternion.identity);
        damageText.GetComponent<Text>().text = damage.ToString();

        //Animation for textNum
        StartCoroutine(AnimateDamageNumber(damageText));
    }

    private IEnumerator AnimateDamageNumber(GameObject damageText)
    {
        float duration = 2f;
        float timer = 0f;

        Vector3 startPos = damageText.transform.position;
        Vector3 endPos = startPos + Vector3.up * 2;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;

            damageText.transform.position = Vector3.Lerp(startPos, endPos, t);
            Color textColor = damageText.GetComponent<Text>().color;
            textColor.a = 1 - t;

            yield return null;
        }

        Destroy(damageText);
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