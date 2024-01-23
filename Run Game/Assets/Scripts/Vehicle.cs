using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : CollisionObject
{
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;


    public float Speed
    {
        set { speed = value; }
        get { return speed; }
    }
    void OnEnable()
    {
        speed = Random.Range(5, 15);
        direction = Vector3.right;
        
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
