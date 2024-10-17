using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameManager.Instance;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameManager.UpdateHealth(10);
        }
    }
}
