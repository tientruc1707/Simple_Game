using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("ChoosePlayer");
    }
    public void HighScore()
    {
        SceneManager.LoadScene("HighScore");
    }
    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
