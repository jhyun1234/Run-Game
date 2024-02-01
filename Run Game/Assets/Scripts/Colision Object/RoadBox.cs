using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoadBox : CollisionObject
{
    [SerializeField] float inintSpeed;
    [SerializeField] UnityEvent callback;

    private void Start()
    {
        inintSpeed = GameManager.instance.Speed;
    }
    public override void Activate(Runnrer runner)
    {
        runner.animator.speed = GameManager.instance.Speed / inintSpeed;
        callback.Invoke();
        
        DataManager.instance.Save();

        GameManager.instance.IncreaseSpeed();
    }
}
