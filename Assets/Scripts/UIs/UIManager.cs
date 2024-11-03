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
        _healthBar.maxValue = StringConstant.PlayerDetail.HEALTH;
        _healthText.text = _healthBar.value + "/" + _healthBar.maxValue;
        _scoreText.text = "Score: " + GameManager.Instance.Score;
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
        _scoreText.text = "Score: " + score;
    }
    public void UpdateHealth(float _currentHealth, float _maxHealth)
    {
        _healthBar.value = _currentHealth;
        _healthText.text = _currentHealth + "/" + _maxHealth;
    }
}
