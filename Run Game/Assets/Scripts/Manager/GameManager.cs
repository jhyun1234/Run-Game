using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public float Speed = 20;
    [SerializeField] public bool state = true;
    [SerializeField] float limit = 50;

    public void GameOver()
    {
        state = false;
    }

    public void IncreaseSpeed()
    {
        if(Speed <limit)
        {
            Speed += 1;
        }
    }

    private void OnEnable()
    {

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = 1.0f;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
