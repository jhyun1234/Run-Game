using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        speed =GameManager.instance.Speed + Random.Range(5, 15);
        direction = Vector3.right;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.state == false)
        {
            return;
        }
        


        transform.Translate(direction * speed * Time.deltaTime);

    }
    public override void Activate(Runnrer runnrer)
    {
        runnrer.animator.Play("Die");
        GameManager.instance.GameOver();
    }
}
