using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static SaveData Instance;
    private const string HIGH_SCORE1 = "high score1";
    private const string SCORE1 = "score1";
    private void Awake()
    {
        MakeInstansce();
        IsGameStartedForTheFirstTime();
    }
    void IsGameStartedForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("IsGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt(HIGH_SCORE1, 0);
            PlayerPrefs.SetInt(SCORE1, 0);
            PlayerPrefs.SetInt("IsGameStartedForTheFirstTime", 0);
        }
    }
    void MakeInstansce()
    {
        if (Instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void SetHighScore(int score)
    {
        if (score > PlayerPrefs.GetInt(HIGH_SCORE1))
        {
            PlayerPrefs.SetInt(HIGH_SCORE1, score);
        }
    }
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE1);
    }
    public int GetScore()
    {
        return PlayerPrefs.GetInt(SCORE1);
    }
    public void SetScore(int score)
    {
        PlayerPrefs.SetInt(SCORE1, score);
    }
    public void Destroy1()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
    }
}
