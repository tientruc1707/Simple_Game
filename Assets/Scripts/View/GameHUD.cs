using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class GameHUD : MonoBehaviour
{

    [SerializeField] private PlayerHealth playerHealth;
    [Header("UI References")]
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _healthText;
    [SerializeField] private Slider _healthBar;
    private void OnEnable()
    {
        InitializeUI();
        SoundManager.Instance.StopBackgroundSound();
        SoundManager.Instance.PlayBackgroundSound(StringConstant.SOUNDS.MAIN_SOUND);
    }

    public void InitializeUI()
    {
        _healthBar.maxValue = StringConstant.PlayerDetail.HEALTH;
        _healthBar.value = _healthBar.maxValue;
        _healthText.text = $"{StringConstant.PlayerDetail.HEALTH}/{StringConstant.PlayerDetail.HEALTH}";
        UpdateScore(DataManager.Instance.GetScore());
    }

    void Update()
    {
        UpdateScore(DataManager.Instance.GetScore());
        UpdateHealth(playerHealth.CurrentHealth, StringConstant.PlayerDetail.HEALTH);
    }
    public void UpdateScore(int score)
    {
        if (_scoreText != null)
        {
            _scoreText.text = $"Score: {score}";
        }
    }

    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        _healthBar.value = currentHealth;
        _healthText.text = $"{currentHealth}/{maxHealth}";
    }

}