using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewTrophies : MonoBehaviour
{
    [SerializeField] private Text _bestScoreText;

    public void Start()
    {
        GameObject textObject = GameObject.Find("Best Score");
        if (textObject != null)
            _bestScoreText = textObject.GetComponent<Text>();
    }
    public void Update()
    {
        _bestScoreText.text = "Best Score: " + DataManager.Instance.GetHighScore();
    }
}
