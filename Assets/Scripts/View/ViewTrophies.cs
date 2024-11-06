using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewTrophies : View
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Text _bestScore;
    public override void Initialize()
    {
        _backButton.onClick.AddListener(() => ViewManager.ShowLast());
        if (_bestScore == null)
        {
            Debug.Log("Missing!");
        }
    }

    public void Update()
    {
        if (_bestScore != null)
            _bestScore.text = "Best Score: " + DataManager.Instance.GetHighScore();
    }
}
