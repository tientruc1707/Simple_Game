using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewTrophies : MonoBehaviour
{
    [SerializeField] private Text _bestScore;

    void Start()
    {
        _bestScore = GetComponent<Text>();
    }
    public void Update()
    {
        if (_bestScore != null)
            _bestScore.text = "Best Score: " + DataManager.Instance.GetHighScore();
    }
}
