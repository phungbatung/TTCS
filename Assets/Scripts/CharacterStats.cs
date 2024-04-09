using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Major stats")]
    public Stat strength; // 1 point increase damage by 1 and crit power by 1%
    public Stat agility;  // 1 point increase evasion by 1% and crit chance by 1%
    public Stat intelligence; // 1 point increase magic damage by 1 and magic registance by 3
    public Stat vitality; // 1 point increase health by 3 or 5 points

    [Header("Offensive stats")]
    public Stat damage;
    public Stat critChance;
    public Stat critPower;


    [Header("Defensive stats")]
    public Stat maxHealth;
    public Stat armor;
    public Stat evasion;
    


    public int currentHealth;
    private float damageScale = 1;

    public Action onHealthChange;
    protected virtual void Start()
    {
        currentHealth = maxHealth.getValue();
        critPower.SetDefaultValue(150);
    }

    public virtual void TakeDamage(int _damage)
    {

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
            

        int totalDamage = Mathf.RoundToInt((damage.getValue()+strength.getValue())*damageScale);
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
        int totalEvasion = _target.evasion.getValue() + _target.agility.getValue();
        if (UnityEngine.Random.Range(0, 100) < totalEvasion)
        {
            Debug.Log("ATTACK AVOIDED");
            return true;
        }
        return false;
    }
    private bool CanCrit()
    {
        int totalCrit=critChance.getValue() + agility.getValue();
        if (UnityEngine.Random.Range(0, 100) < totalCrit)
            return true;
        return false;
    }

    private int CriticalDamage(int _damage)
    {
        float totalCritPower = (critPower.getValue() + strength.getValue()) * .01f;
        float finalDamage=_damage*totalCritPower;
        return Mathf.RoundToInt(finalDamage);
    }
    public void SetDamageScale(float _scale)
    {
        damageScale += _scale;
    }
    public float GetMaxHealth()
    {
        return (float)maxHealth.getValue() + vitality.getValue()*5;
    }
        
}
