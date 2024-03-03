using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimationTriggers : MonoBehaviour
{
    private Enemy_Skeleton enemy;
    private void Start()
    {
        enemy = GetComponentInParent<Enemy_Skeleton>();
    }
    public virtual void AnimationTriggerCalled()
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
                hit.GetComponent<Player>().Damaged();
            }
        }
    }

}
