using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public UnityEvent LevelCompleted = new();
    public UnityEvent LevelFailed = new();


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
        }
    }
    public void CompleteLevel()
    {
        LevelCompleted?.Invoke();
    }
    public void FailLevel()
    {
        LevelFailed?.Invoke();
    }

}