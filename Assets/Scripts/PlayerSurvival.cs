using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSurvival : MonoBehaviour
{
    public static PlayerSurvival Instance { get; private set; }
    public float currentDamage;
    public float maxHealth;
    public float currentHealth;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        maxHealth = 100f;
        currentDamage = 25f;
    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {

    }
}
