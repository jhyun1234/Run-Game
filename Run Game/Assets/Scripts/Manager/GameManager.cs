using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] public float Speed = 20;
    [SerializeField] public bool state = true;
    [SerializeField] float limit = 50;
    public float minRandomSpeed = 5f;
    public float maxRandomSpeed = 20f;
    private GameObject panel;
    private Transform parent;
    
    public void ControlRandomSpeed()
    {
        if (minRandomSpeed < maxRandomSpeed-1)
        {
            minRandomSpeed++;
        }
    }

    public void GameOver()
    {

        parent = GameObject.Find("UI Canvas").GetComponent<Transform>();

        if (panel == null)
        {
            panel = Instantiate(Resources.Load<GameObject>("GameOver Panel"), parent);

        }
        else
        {
            panel.SetActive(true);
        }
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
        Speed = 20;
        state = true;
        Time.timeScale = 1.0f;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
