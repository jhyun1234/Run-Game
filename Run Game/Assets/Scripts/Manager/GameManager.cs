using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
