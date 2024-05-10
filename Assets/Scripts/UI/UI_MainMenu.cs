using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField] private string sceneName = "MainScene";
    [SerializeField] private UI_FadeScreen fadeScreen;
    public void ContinueGame()
    {
        StartCoroutine(LoadSceneWithFadeEffect(1.5f));
    }

    public void NewGame()
    {
        SaveManager.instance.DeleteSavedData();
        StartCoroutine(LoadSceneWithFadeEffect(1.5f));
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
    }

    IEnumerator LoadSceneWithFadeEffect(float  fadeTime)
    {
        fadeScreen.FadeOut();

        yield return new WaitForSeconds(fadeTime);

        SceneManager.LoadScene(sceneName);
    }
}
