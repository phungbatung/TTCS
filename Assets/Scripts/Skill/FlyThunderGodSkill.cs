using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyThunderGodSkill : Skill
{
    [SerializeField] private GameObject swordPrefab;
    [SerializeField] private GameObject teleportThunder;
    [SerializeField] private int damage;
    [SerializeField] private float velocity;
    [SerializeField] private float acceleration;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask groundLayer;
    public bool canBeUseSkill;
    public bool canBeTeleport;
    public bool executeTeleport;
    public ThunderSwordController swordScript;

    protected override void Start()
    {
        base.Start();
        canBeUseSkill = true;
        canBeTeleport = false;
        executeTeleport = false;
}
    protected override void Update()
    {
        base.Update();
        CheckForTeleport();
        TeleportLogic();
    }
    public void CreateSword(Transform _transform)
    {
        GameObject newSword = swordPrefab.Spawn();
        swordScript = newSword.GetComponent<ThunderSwordController>();
        swordScript.SetUpSword(_transform, 0, (float)player.facingDir, velocity, acceleration, maxDistance, damage);
        canBeUseSkill = false;
    }
    private void CheckForTeleport()
    {
        if (canBeTeleport && Input.GetKeyDown(KeyCode.E))
        {
            player.stateMachine.ChangeState(player.teleportState);
            GameObject thunder = teleportThunder.Spawn();
            TeleportThunderController teleportThunderScript = thunder.GetComponent<TeleportThunderController>();
            teleportThunderScript.SetupThunder(player.transform, false);
            canBeTeleport = false;
            swordScript.canBeDestroy = false;
        }
    }
    private void TeleportLogic()
    {
        if (executeTeleport && swordScript!=null)
        {
            executeTeleport = false;
            float direction = player.transform.position.x - swordScript.transform.position.x;
            direction = .7f * direction / Mathf.Abs(direction);
            if (!Physics2D.Raycast(swordScript.transform.position + new Vector3(direction, 0, 0), Vector2.down, .1f, groundLayer))
            {
                Debug.Log("log1");
                player.PlayerTeleportTo(swordScript.transform.position + new Vector3(direction, 0, 0));
            }
            else if (!Physics2D.Raycast(swordScript.transform.position + new Vector3(-direction, 0, 0), Vector2.down, .1f, groundLayer))
            {
                Debug.Log("log2");
                player.PlayerTeleportTo(swordScript.transform.position + new Vector3(-direction, 0, 0));
            }
            else
            {
                Debug.Log("log3");
                player.PlayerTeleportTo(swordScript.transform.position);
            }
            TeleportThunderController thunderScript = teleportThunder.Spawn().GetComponent<TeleportThunderController>();
            thunderScript.SetupThunder(player.transform, true);
            thunderScript.transform.parent = player.transform;
            swordScript.gameObject.Despawn();
        }
    }
    public override bool CanBeUse()
    {
        if (!canBeUseSkill) 
            return false;
        else
        return base.CanBeUse();
    }
}
