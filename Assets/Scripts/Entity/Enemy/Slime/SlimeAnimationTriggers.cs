using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimationTriggers : MonoBehaviour
{
    private Enemy enemy;
    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }
    private void AnimationTriggerCalled()
    {
        enemy.AnimationTriggerCalled();
    }

    private void Jump()
    {
        float t = - 2 * enemy.jumpForce/(enemy.rb.gravityScale * Physics2D.gravity.y);
        float xVelocity = (PlayerManager.instance.player.transform.position.x - enemy.transform.position.x)/t;
        enemy.SetVelocity(xVelocity, enemy.jumpForce);
    }

}
