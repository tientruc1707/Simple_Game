using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Score { get; private set; }
    public int _maxPlayerHealth = 100;
    public int Health { get; private set; }


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
        Score = 0;
        Health = _maxPlayerHealth;
    }
    public void UpdateScore(int point)
    {
        Score += point;
        UIManager.Instance.UpdateScore(Score);
    }
    public void UpdateHealth(float dmg)
    {
        if (Health > 0)
            Health -= (int)dmg;
        UIManager.Instance.UpdateHealth(Health, _maxPlayerHealth);
        //         if (Health <= 0)
        //         {
        //              GameOver();
        //         }
    }
}
