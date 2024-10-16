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



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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
        _healthText.text = _currentHealth + "/" + _maxHealth;
        _healthBar.value = (float)_currentHealth / _maxHealth;
    }
}
