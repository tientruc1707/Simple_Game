using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ViewPlaying : View
{
    [SerializeField] private Button _pauseButton;
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    public override void Initialize()
    {
        _pauseButton.onClick.AddListener(() => ViewManager.Open<ViewPauseGame>());
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    void Update()
    {
        if (!gameManager.Alive)
        {
            ViewManager.Show<ViewFail>();
        }
        if (gameManager.CompleteLevel)
        {
            ViewManager.Show<ViewPass>();
        }
    }
}
