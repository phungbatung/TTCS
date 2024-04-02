using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField]protected Stat damage;
    [SerializeField]protected Stat maxHealth;
    [SerializeField]protected int currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth.getValue();
    }

    public virtual void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        if (currentHealth <= 0) 
        {
            currentHealth = 0;
            Die();
        }
    }
    public virtual void DoDamage(CharacterStats _target)
    {
        _target.TakeDamage(damage.getValue());
    }
    public virtual void Die()
    {

    }
}
