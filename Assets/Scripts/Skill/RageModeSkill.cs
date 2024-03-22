using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageModeSkill : Skill
{
    [SerializeField]private GameObject ghostPrefab;
    
    private Color baseColor;
    [SerializeField]private Color rageColor;
    public SpriteRenderer sr;


    private float rageTimer;
    [SerializeField] private float rageDuration=0;
    [SerializeField] private float invisibleSpeed;
    [SerializeField]private float spawnRate;
    private float spawnTimer=0;
    private float speed;
    private float baseSpeed;


    protected override void Start()
    {
        base.Start();
        sr = player.GetComponentInChildren<SpriteRenderer>();
        baseColor =sr.color;
        baseSpeed = player.moveSpeed;
        
    }
    protected override void Update()
    {
        base.Update();
        spawnTimer -= Time.deltaTime;
        speed = Mathf.Abs(player.rb.velocity.x);
        if (rageTimer > 0)
            RageMode();
            
    }
    public void SetUpRage()
    {
        rageTimer = rageDuration;
        sr.color = rageColor;
    }
    public void RageMode()
    {
        rageTimer -= Time.deltaTime;
        
        if(spawnTimer<0 && speed!=0)
        {
            CreateGhost();
            if (speed>baseSpeed)
                spawnTimer = baseSpeed * spawnRate / speed;
            else
                spawnTimer = spawnRate;
        }
        if (rageTimer<0)
            SetNormalMode();
    } 
    public void SetNormalMode()
    {
        sr.color = baseColor;
    }
    
    private void CreateGhost()
    {
        GameObject ghost = Instantiate(ghostPrefab);
        GhostController ghostScripts = ghost.GetComponent<GhostController>();
        ghostScripts.SetUpGhost(player.transform, sr.sprite, rageColor, invisibleSpeed, player.facingDir);
    }

}
