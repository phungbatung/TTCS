using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerOfDeadAnimationTriggers : MonoBehaviour
{
    private Enemy_BringerOfDead enemy;
    private void Start()
    {
        enemy = GetComponentInParent<Enemy_BringerOfDead>();
    }
    private void AnimationTriggerCalled()
    {
        enemy.AnimationTriggerCalled();
    }
    private void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackPoint.position, enemy.attackRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                enemy.stats.DoDamage(hit.GetComponent<CharacterStats>());
            }
        }
    }
    private void TeleportToPlayer()
    {
        enemy.transform.position = new Vector2(PlayerManager.instance.player.transform.position.x + (enemy.transform.position.x - enemy.attackPoint.position.x), enemy.transform.position.y);
    }
    private void SpawnDeadHand()
    {
        enemy.SpawnDeadHand();
    }
}
