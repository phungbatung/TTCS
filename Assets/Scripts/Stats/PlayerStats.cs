using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private Player player;
    protected override void Start()
    {
        base.Start();
        player = GetComponent<Player>();
    }
    public override void TakeDamage(int _damage)
    {
        base.TakeDamage(_damage);
        player.DamagedEffect();
    }
    public override void Die()
    {
        base.Die();
        player.stateMachine.ChangeState(player.deadState);
    }    
}
