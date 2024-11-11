using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI References")]
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _healthText;
    [SerializeField] private Slider _healthBar;

    public bool fadeToBlack, fadeFromBlack;
    public Image blackScreen;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        InitializeUI();
    }

    private void InitializeUI()
    {
        _healthBar.value = GameManager.Instance.Health;
        _healthBar.maxValue = StringConstant.PlayerDetail.HEALTH;
        _healthText.text = $"{_healthBar.value}/{_healthBar.maxValue}";
        _scoreText.text = $"Score: {GameManager.Instance.Score}";
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
        if (_healthBar != null)
        {
            _healthBar.value = currentHealth;
        }

        if (_healthText != null)
        {
            _healthText.text = $"{currentHealth}/{maxHealth}";
        }
    }
    //Create new UI if needed
    public void CreateNewUIElements(Transform canvas)
    {
        if (canvas == null)
        {
            Debug.LogError("Canvas reference is missing!");
            return;
        }

        if (_healthBar == null)
        {
            _healthBar = Instantiate(_healthBar, canvas);
            _healthBar.transform.position = new Vector3(365, -80, 0);

            if (_scoreText == null)
            {
                _scoreText = Instantiate(_scoreText, canvas);
                _scoreText.transform.position = new Vector3(25, -80, 0);
            }

            if (_healthText == null)
            {
                _healthText = Instantiate(_healthText, canvas);
                _healthText.transform.position = Vector3.zero;
            }
            InitializeUI();
        }
    }
    private void FadeScreen(float targetAlpha)
    {
        Color currentColor = blackScreen.color;
        float newAlpha = Mathf.MoveTowards(currentColor.a, targetAlpha, 2f * Time.deltaTime);
        blackScreen.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
    }
}