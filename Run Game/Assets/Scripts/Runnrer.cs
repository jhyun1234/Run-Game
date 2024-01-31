using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum RoadLine
{
    LEFT=-1,
    MIDDLE,
    RIGHT,

}
public class Runnrer : MonoBehaviour
{
    public Animator animator;

    [SerializeField] float Lerpspeed = 25.0f;
    [SerializeField] float positionX = 3.5f;
    [SerializeField] RoadLine line;
    [SerializeField] RoadLine previousRoadLine;
    private void OnEnable()
    {
        InputManager.instance.keyAction += Move;
    }

    void Start()
    {
        line = RoadLine.MIDDLE;
        
        previousRoadLine = RoadLine.MIDDLE;

        InputManager.instance.keyAction += Move;
    }

    
    void Update()
    {
        
        Status();
    }

    public void Move()
    {
        if (GameManager.instance.state == false)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
            if(line>RoadLine.LEFT)
            {
                animator.Play("Left Avoid");
                previousRoadLine = line;
                line--;
            }
        }
         
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
           
            if(line<RoadLine.RIGHT)       
            {
                animator.Play("Right Avoid");
                previousRoadLine = line;
                line++;
            }
        }

        
    }

    public void Status()
    {
        switch(line)
        {
            case RoadLine.LEFT:
                SmoothMovement(-positionX);
                break;
            case RoadLine.MIDDLE:
                SmoothMovement(0);
                break;
            case RoadLine.RIGHT:
                SmoothMovement(positionX);
                break;
    
        }
    
    }
    public void ReverPosition()
    {
        line = previousRoadLine;
    }
   public void SmoothMovement(float positionX)
   {
       transform.position =  Vector3.Lerp(transform.position,new Vector3(positionX,0,0),Lerpspeed* Time.deltaTime);
   
   }
    private void OnTriggerEnter(Collider other)
    {
        CollisionObject collisionObject = other.GetComponent<CollisionObject>();

        if(collisionObject !=null)
        {
            collisionObject.Activate(this);
        }
    }

    private void OnDisable()
    {
        InputManager.instance.keyAction -= Move;
    }
}
