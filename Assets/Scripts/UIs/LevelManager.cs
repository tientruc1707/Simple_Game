using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    public bool IsUnlock { get; set; }
    [SerializeField] private int _currentLevel;
    void Start()
    {
        for (int i = 0; i < buttons.Length; ++i)
        {
            string lv = (i + 1).ToString();
            buttons[i].onClick.AddListener(() => LoadLevel(lv));
        }
    }
    private void LoadLevel(string lv)
    {
        SceneManager.LoadScene("Level " + lv);
    }
    public void LoadNextLevel()
    {
        _currentLevel++;
        SceneManager.LoadScene("Level " + _currentLevel.ToString());
    }
    void OnDrawGizmosSelected()
    {
        buttons = GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; ++i)
        {
            buttons[i].name = "Level " + (i + 1).ToString();
            IsUnlock = false;
        }
    }
}
