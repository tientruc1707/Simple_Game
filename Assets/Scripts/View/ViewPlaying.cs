using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StateManager : MonoBehaviour
{
    public GameObject loseGameGUI;
    public GameObject winGameGUI;
    public GameObject pauseGameGUI;
    public Text Score1, BestScore1, Score2, BestScore2;
    public int levelToUnlock;
    private int levelMaxUnlocked;

    public GameObject playGameGUI;



    void Start()
    {
        playGameGUI.SetActive(true);
        winGameGUI.SetActive(false);
        loseGameGUI.SetActive(false);
        pauseGameGUI.SetActive(false);
    }
    private void Update()
    {
        Score1.text = Score2.text = "" + GameManager.Instance.Score;
        BestScore1.text = BestScore2.text = "" + DataManager.Instance.GetHighScore();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        if (!GameManager.Instance.Alive)
        {
            LoseGame();
        }
        if (GameManager.Instance.CompleteLevel)
        {
            WinGame();
        }
    }
    public void LoseGame()
    {
        Time.timeScale = 0f;
        if (!loseGameGUI.activeSelf)
        {
            loseGameGUI.SetActive(true);
            Score2.gameObject.SetActive(true);
            BestScore2.gameObject.SetActive(true);
        }
    }

    public void WinGame()
    {
        if (!winGameGUI.activeSelf)
        {
            winGameGUI.SetActive(true);
            Score1.gameObject.SetActive(true);
            BestScore1.gameObject.SetActive(true);
        }
        if (levelMaxUnlocked < levelToUnlock)
        {
            levelMaxUnlocked = levelToUnlock;
        }

        PlayerPrefs.SetInt("levelReached", levelMaxUnlocked);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        if (!pauseGameGUI.activeSelf)
        {
            pauseGameGUI.SetActive(true);
            playGameGUI.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            pauseGameGUI.SetActive(false);
            playGameGUI.SetActive(true);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
