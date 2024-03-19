using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSkill : Skill
{
    [SerializeField]private GameObject clonePrefab;

    public void CreateClone(Transform _transform, int _facingDir)
    {
        GameObject newClone = Instantiate(clonePrefab);
        newClone.GetComponent<CloneControllers>().SetUpClone(_transform, _facingDir);
    }
}
