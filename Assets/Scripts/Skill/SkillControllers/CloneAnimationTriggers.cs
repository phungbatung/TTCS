using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneAnimationTriggers : MonoBehaviour
{
    private CloneControllers clone;
    void Start()
    {
        clone = GetComponentInParent<CloneControllers>();
    }

    private void AnimationTriggerCalled()
    {
    }

    private void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(clone.attackPoint.position, clone.attackRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                hit.GetComponent<Enemy>().DamagedEffect();
            }
        }
    }

}
