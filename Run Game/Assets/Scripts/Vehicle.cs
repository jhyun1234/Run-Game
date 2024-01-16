using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : CollisionObject
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] Vector3 direction;


    void OnEnable()
    {
        direction = Vector3.forward;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

    }
    public override void Activate(Runnrer runnrer)
    {
        Debug.Log("Game Over");
    }
}
