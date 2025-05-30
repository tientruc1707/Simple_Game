

using UnityEngine;
using UnityEngine.SceneManagement;


public class StateManager : MonoBehaviour
{
    [SerializeField] private GameObject _levelPlay;
    [SerializeField] private GameObject _levelFail;
    [SerializeField] private GameObject _levelPass;
    [SerializeField] private GameObject _levelPause;


    [SerializeField] private PlayerHealth playerHealth;

    void OnEnable()
    {
        InitializeUI();
        GameManager.Instance.LevelCompleted.AddListener(WinGame);
        GameManager.Instance.LevelFailed.AddListener(LoseGame);
    }
    void OnDisable()
    {
        GameManager.Instance.LevelCompleted.RemoveListener(WinGame);
        GameManager.Instance.LevelFailed.RemoveListener(LoseGame);
    }
    private void InitializeUI()
    {
        Time.timeScale = 1;
        _levelPlay.SetActive(true);
        _levelPass.SetActive(false);
        _levelFail.SetActive(false);
        _levelPause.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
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
        if (_levelFail.activeSelf || _levelPass.activeSelf)
        {
            _levelFail.SetActive(false);
            _levelPass.SetActive(false);
        }
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
