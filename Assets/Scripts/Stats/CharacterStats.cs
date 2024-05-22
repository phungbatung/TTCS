using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    [Header("Offensive stats")]
    public Stat damage; // Weapon
    public Stat critChance; // Gaunlets
    public Stat critPower; // Helmet


    [Header("Defensive stats")]
    public Stat maxHealth; // Pants
    public Stat armor; // Chestplate
    public Stat evasion; // Boots
    


    public int currentHealth;
    private float damageScale = 1;

    public Action onHealthChange;
    public bool isImmortal;
    protected virtual void Start()
    {
        currentHealth = maxHealth.getValue();
        critPower.SetDefaultValue(150);
    }

    public virtual void TakeDamage(int _damage)
    {
        if (isImmortal)
            return;
        if (UnityEngine.Random.Range(0, 100) <= evasion.getValue())
            return;
        currentHealth -= _damage;
        if (onHealthChange!=null)
            onHealthChange();
        if (currentHealth <= 0) 
        {
            currentHealth = 0;
            Die();
        }
    }
    public virtual void DoDamage(CharacterStats _target)
    {
        if (TargetCanAvoidAttack(_target))
            return;
            

        int totalDamage = Mathf.RoundToInt((damage.getValue())*damageScale);
        if (CanCrit())
            totalDamage = CriticalDamage(totalDamage);
        totalDamage -= armor.getValue();
        totalDamage = Mathf.Clamp(totalDamage, 0, int.MaxValue);
        _target.TakeDamage(totalDamage);
    }


    public virtual void Die()
    {

    }
    private bool TargetCanAvoidAttack(CharacterStats _target)
    {
        int totalEvasion = _target.evasion.getValue();
        if (UnityEngine.Random.Range(0, 100) < totalEvasion)
        {
            Debug.Log("ATTACK AVOIDED");
            return true;
        }
        return false;
    }
    private bool CanCrit()
    {
        int totalCrit=critChance.getValue();
        if (UnityEngine.Random.Range(0, 100) < totalCrit)
            return true;
        return false;
    }

    private int CriticalDamage(int _damage)
    {
        float totalCritPower = (critPower.getValue()) * .01f;
        float finalDamage=_damage*totalCritPower;
        return Mathf.RoundToInt(finalDamage);
    }
    public void SetDamageScale(float _scale)
    {
        damageScale += _scale;
    }
    public float GetMaxHealth()
    {
        return (float)maxHealth.getValue();
    }

    public string GetOffensiveStats()
    {
        return $"{damage.getValue()}\n{critChance.getValue()}%\n{critPower.getValue()}%";
    }
    public string GetDeffensiveStats()
    {
        return $"{maxHealth.getValue()}\n{armor.getValue()}\n{evasion.getValue()}%";
    }
        
}
