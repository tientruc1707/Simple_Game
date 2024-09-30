using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorSurvival : MonoBehaviour, IDamage, IPlayer
{
    float currentDamage;
    float startHealth;
    float currentHealth;

    public float Damage { get => currentDamage; }
    public string IsPlayer { get; set; }


    void Awake()
    {
        startHealth = 100f;
        currentDamage = 25f;
    }
    void Start()
    {
        currentHealth = startHealth;
    }

    void Update()
    {

    }
    void IDamage.DealDamage(float damage)
    {

    }
    void IDamage.TakeDamage(float damage)
    {

    }

}
