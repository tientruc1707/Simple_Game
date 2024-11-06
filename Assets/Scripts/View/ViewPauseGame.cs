using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ViewPauseGame : View
{
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _homeButton;
    public override void Initialize()
    {
        _resumeButton.onClick.AddListener(() => ViewManager.ShowLast());
    }
    public void Resume()
    {
        ReturnTime();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ReturnTime();
    }
    public void Home()
    {
        SceneManager.LoadScene(StringConstant.GameScene.MAINMENU);
        ReturnTime();
    }
    private void ReturnTime()
    {
        Time.timeScale = 1;
    }
}
