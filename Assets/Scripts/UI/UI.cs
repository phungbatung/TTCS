using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private UI_FadeScreen fadeScreen;
    [SerializeField] private GameObject youDied;

    public IEnumerator Die()
    {
        yield return new WaitForSeconds(.5f);
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(1f);
        youDied.SetActive(true);
    }
}
