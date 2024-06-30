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
    [Header("Normal mode")]
    [SerializeField] private float gravity;
    [SerializeField] private int damage;
    
    protected override void Start()
    {
        base.Start();
        GenerateDots();
    }

    protected override void Update()
    {
        SetDotsPosition();
        /*if (Input.GetKeyUp(KeyCode.Mouse1))
            finalDirection = new Vector2(AimDirection().normalized.x * launchDir.x, AimDirection().normalized.y * launchDir.y);*/
    }

    public void CreateSword(Transform _transform)
    {
        GameObject newSword = swordPrefab.Spawn();

        SwordController swordScript = newSword.GetComponent<SwordController>();
        damage = player.stats.damage.getValue() * 2;
        swordScript.SetUpSword(_transform, gravity, finalDirection, damage);
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
            + new Vector2(AimDirection().normalized.x*launchDir.x, AimDirection().normalized.y*launchDir.y)*t + 0.5f*Physics2D.gravity* gravity * t*t;
        return position;
    }
    public void SwitchActiveDots(bool _active)
    {
        for(int i=0; i<numberOfDots; i++)
            listOfDots[i].SetActive(_active);
    }

}
