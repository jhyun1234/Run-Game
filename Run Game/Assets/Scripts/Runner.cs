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
    [SerializeField] float positionX = 3.5f;
    [SerializeField] RoadLine line;
    void Start()
    {
        line = RoadLine.MIDDLE;
    }

    
    void Update()
    {
        Move();
        Status();
    }

    public void Move()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(line>RoadLine.LEFT)
            {
                line--;
            }
        }
         
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(line<RoadLine.RIGHT)       
            {
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

    public void SmoothMovement(float positionX)
    {
        transform.position = new Vector3(positionX, 0, 0);

    }
}
