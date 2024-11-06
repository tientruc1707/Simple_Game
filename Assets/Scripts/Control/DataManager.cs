using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager _instance;

    public static DataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("DataManager");
                _instance = obj.AddComponent<DataManager>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    private const string LevelKey = "CurrentLevel";
    private const string ScoreKey = "PlayerScore";
    private const string BestScore = "BestScore";

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(LevelKey))
        {
            SetLevel(1); // Mặc định là level 1
        }
        if (!PlayerPrefs.HasKey(ScoreKey))
        {
            SetScore(0); // Mặc định là 0 điểm
        }
        if (!PlayerPrefs.HasKey(BestScore))
        {
            SetHighScore(0);
        }
    }

    public void SetLevel(int level)
    {
        PlayerPrefs.SetInt(LevelKey, level);
        PlayerPrefs.Save();
    }
    public void SetScore(int score)
    {
        PlayerPrefs.SetInt(ScoreKey, score);
        PlayerPrefs.Save();
    }
    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(BestScore, score);
        PlayerPrefs.Save();
    }
    public int GetLevel()
    {
        return PlayerPrefs.GetInt(LevelKey);
    }
    public int GetScore()
    {
        return PlayerPrefs.GetInt(ScoreKey);
    }
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(BestScore);
    }
    // Xóa dữ liệu
    public void ResetData()
    {
        PlayerPrefs.DeleteKey(LevelKey);
        PlayerPrefs.DeleteKey(ScoreKey);
        PlayerPrefs.Save();
    }
}