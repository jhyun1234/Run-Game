using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Vehicle : CollisionObject
{
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;
    [SerializeField] float minRandomSpeed = 5f;
    [SerializeField] float maxRandomSpeed = 20f;
    public float Speed
    {
        set { speed = value; }
        get { return speed; }
    }
    void OnEnable()
    {
        if(minRandomSpeed < 19)
        {
          minRandomSpeed += 1;
          

        }

        direction = Vector3.right;

        speed =GameManager.instance.Speed + Random.Range(minRandomSpeed, maxRandomSpeed);
        
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
