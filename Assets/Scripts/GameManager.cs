using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    
    public void RestartScene()
    {
        SaveManager.instance.SaveGame();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void LoadScene(string _sceneName)
    {
        SaveManager.instance.SaveGame();
        SceneManager.LoadScene(_sceneName);
    }
    public void Revive()
    {
        PlayerManager.instance.player.stateMachine.ChangeState(PlayerManager.instance.player.idleState);
        PlayerManager.instance.player.stats.currentHealth = PlayerManager.instance.player.stats.maxHealth.getValue();
        Pause(true);
    }
    public void Pause(bool _pause)
    {
        if (_pause)
            Time.timeScale = 1.0f;
        else
            Time.timeScale = 0f;
    }
}
