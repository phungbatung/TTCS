using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ThrowSwordSkill : Skill
{

    [SerializeField] private GameObject swordPrefab;
    [SerializeField] private GameObject dotsPrefab;
    [SerializeField] private Transform dotsParent;
    [SerializeField] private int numberOfDots;
    [SerializeField] private float spaceBetweenDots;
    private GameObject[] listOfDots;

    
    private Vector2 finalDirection;
    [SerializeField] private Vector2 launchDir;
    private float gravity;

    public bool isBoomarang = false;
    [Header("Normal mode")]
    [SerializeField] private float normalGravity;
    [SerializeField] private int normalDamage;

    [Header("Boomerang mode")]
    [SerializeField] private float boomarangGravity;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxDistance;
    [SerializeField] private int boomerangDamage;
    
    protected override void Start()
    {
        base.Start();
        GenerateDots();
        gravity = normalGravity;
    }

    protected override void Update()
    {
        SetDotsPosition();
        if (Input.GetKeyUp(KeyCode.Mouse1))
            finalDirection = new Vector2(AimDirection().normalized.x * launchDir.x, AimDirection().normalized.y * launchDir.y);
    }

    public void SetBomerangMode() => isBoomarang = true;
    public void SetNormalMode() => isBoomarang = false;
    public void CreateSword(Transform _transform)
    {
        GameObject newSword = swordPrefab.Spawn();

        SwordController swordScript = newSword.GetComponent<SwordController>();
        if (isBoomarang) gravity = boomarangGravity;
        else gravity = normalGravity;
        swordScript.SetUpSword(_transform, gravity, isBoomarang);
        boomerangDamage = (int)(player.stats.damage.getValue() * .4f);
        normalDamage = player.stats.damage.getValue() * 2;
        if (isBoomarang)
            swordScript.SetUpBoomarang(player.facingDir, moveSpeed, maxDistance, boomerangDamage);
        else
            swordScript.SetUpNormal(finalDirection, normalDamage);
        
        SwitchActiveDots(false);
    }

    private Vector2 AimDirection()
    {
        Vector2 startPosition = player.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - startPosition;
        return  direction;
    }
    private void GenerateDots()
    {
        listOfDots = new GameObject[numberOfDots];
        for (int i=0; i<numberOfDots; i++)
        {
            listOfDots[i] = Instantiate(dotsPrefab,new Vector2(0, 0), Quaternion.identity, dotsParent);
            listOfDots[i].SetActive(false);
        }
    }
    private void SetDotsPosition()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            for (int i = 0; i < numberOfDots; i++)
            {
                listOfDots[i].transform.position = dotsPosition(i * spaceBetweenDots);
            }
        }
    }
    private Vector2 dotsPosition(float t)
    {
        Vector2 position=(Vector2)player.transform.position 
            + new Vector2(AimDirection().normalized.x*launchDir.x, AimDirection().normalized.y*launchDir.y)*t + 0.5f*Physics2D.gravity* normalGravity * t*t;
        return position;
    }
    public void SwitchActiveDots(bool _active)
    {
        if(isBoomarang)
            _active = false;
        for(int i=0; i<numberOfDots; i++)
            listOfDots[i].SetActive(_active);
    }

}
