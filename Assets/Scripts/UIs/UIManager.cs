using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Slider _healthBar;

    private void Start()
    {
        _healthBar.value = GameManager.Instance.Health;
        _healthBar.maxValue = GameManager.Instance._maxPlayerHealth;
        _healthText.text = _healthBar.value + "/" + _healthBar.maxValue;
        _scoreText.text = "Score: " + GameManager.Instance.Score.ToString();
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void UpdateScore(int score)
    {
        _scoreText.text = "Score: " + score.ToString();
    }
    public void UpdateHealth(int _currentHealth, int _maxHealth)
    {
        _healthBar.value = _currentHealth;
        _healthText.text = _currentHealth + "/" + _maxHealth;
    }
}
