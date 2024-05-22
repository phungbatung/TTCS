using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BringerOfDead : Enemy
{
    [SerializeField] private GameObject deadHandPrefab;

    public float teleportCooldown;
    public float ultimateCooldown;

    public float teleportTimer;
    public float ultimateTimer;

    public BringerOfDeadIdleState idleState;
    public BringerOfDeadMoveState moveState;
    public BringerOfDeadBattleState battleState;
    public BringerOfDeadAttackState attackState;
    public BringerOfDeadTeleportState teleportState;
    public BringerOfDeadUltimateState ultimateState;
    public BringerOfDeadDeadState deadState;
    protected override void Start()
    {
        base.Start();
        idleState = new BringerOfDeadIdleState(this, stateMachine, "idle");
        moveState = new BringerOfDeadMoveState(this, stateMachine, "move");
        battleState = new BringerOfDeadBattleState(this, stateMachine, "move");
        attackState = new BringerOfDeadAttackState(this, stateMachine, "attack");
        teleportState = new BringerOfDeadTeleportState(this, stateMachine, "tele");
        ultimateState = new BringerOfDeadUltimateState(this, stateMachine, "ulti");
        deadState = new BringerOfDeadDeadState(this, stateMachine, "dead");
        stateMachine.InitialState(idleState);
    }
    protected override void Update()
    {
        base.Update();
        teleportTimer -= Time.deltaTime;
        ultimateTimer -= Time.deltaTime;
    }

    public bool CanBeUseTeleport()
    {
        if (teleportTimer > 0) return false;
        teleportTimer = teleportCooldown;
        return true;
    }

    public bool CanBeUseUltimate()
    {
        if (ultimateTimer > 0) return false;
        ultimateTimer = ultimateCooldown;
        return true;
    }

    public void SpawnDeadHand()
    {
        Player player = PlayerManager.instance.player;
        GameObject skill = Instantiate(deadHandPrefab, new Vector2(player.transform.position.x, player.transform.position.y + 1.2f), Quaternion.identity);
    }
    public RaycastHit2D IsPlayerInZone()
    {
        return Physics2D.Raycast(new Vector2(6, -1), Vector2.right, 33-6, playerLayer);
    }
}
