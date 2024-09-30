using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage
{
    public float Damage { get; }
    void DealDamage(float damage);
    void TakeDamage(float damage);
}
