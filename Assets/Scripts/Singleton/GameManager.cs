using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Score { get; private set; }
    public float Health { get; private set; }
    public bool PlayerAttack { get; set; }
    public bool Alive { get; set; }
    public bool CompleteLevel { get; set; }

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
        Alive = true;
        Score = 0;
        Health = StringConstant.PlayerDetail.HEALTH;
        CompleteLevel = false;
    }
    public void HealthRegen()
    {
        Health = StringConstant.PlayerDetail.HEALTH;
        UIManager.Instance.UpdateHealth(Health, StringConstant.PlayerDetail.HEALTH);
    }
    public void UpdateScore(int point)
    {
        Score += point;
        UIManager.Instance.UpdateScore(Score);
    }
    public void UpdateHealth(float dmg)
    {
        if (Health > 0)
            Health -= dmg;
        UIManager.Instance.UpdateHealth(Health, StringConstant.PlayerDetail.HEALTH);
        if (Health <= 0)
        {
            Alive = false;
        }
    }
}
