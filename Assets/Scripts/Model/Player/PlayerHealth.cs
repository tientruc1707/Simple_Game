using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{

    public UnityEvent OnPlayerHeal = new();
    public float CurrentHealth { get; private set; }
    private bool isVulnerable = true;

    void Start()
    {
        CurrentHealth = StringConstant.PlayerDetail.HEALTH;
        OnPlayerHeal.AddListener(() => Heal(30));
    }

    public void TakeDamage(float damage)
    {
        if (!isVulnerable) return;
        else
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                GameManager.Instance.FailLevel();
                return;
            }
            StartCoroutine(InvulnerabilityCoroutine(2));
        }
    }

    IEnumerator InvulnerabilityCoroutine(int v)
    {
        yield return new WaitForSecondsRealtime(v);
        isVulnerable = true;
    }

    private void Heal(float amount)
    {
        CurrentHealth += amount;
        if (CurrentHealth > StringConstant.PlayerDetail.HEALTH)
        {
            CurrentHealth = StringConstant.PlayerDetail.HEALTH;
        }
    }

    public void Heal()
    {
        OnPlayerHeal?.Invoke();
    }
}
