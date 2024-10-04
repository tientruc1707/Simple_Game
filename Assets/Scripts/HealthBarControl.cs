using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarControl : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHealth = 100f;
    public float currentHealth;
    public float lerpSpeed = 0.05f;
    void Start()
    {
        // maxHealth = PlayerSurvival.Instance.maxHealth;
        // currentHealth = PlayerSurvival.Instance.currentHealth;
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthSlider.value != currentHealth)
        {
            healthSlider.value = currentHealth;
        }
        if (Input.GetMouseButtonDown(0))
        {
            TakeDmg(10f);
        }
        if (healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, currentHealth, lerpSpeed);
        }
    }
    void TakeDmg(float dmg)
    {
        currentHealth -= dmg;
    }
}
