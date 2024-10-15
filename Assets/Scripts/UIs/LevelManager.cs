using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    void Start()
    {
        for (int i = 0; i < buttons.Length; ++i)
        {
            string lv = (i + 1).ToString();
            buttons[i].onClick.AddListener(() => LoadLevel(lv));
        }
    }
    private void LoadLevel(string name)
    {
        SceneManager.LoadScene("Level " + name);
    }
    void OnDrawGizmosSelected()
    {
        buttons = GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; ++i)
        {
            Text lvText = buttons[i].GetComponentInChildren<Text>();
            lvText.text = (i + 1).ToString();
            lvText.fontSize = 80;
            lvText.fontStyle = FontStyle.Bold;
            lvText.alignByGeometry = true;
            buttons[i].name = "Level " + lvText;
        }
    }
}
