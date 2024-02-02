using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE,
    RIGHT
}

public class Runner : MonoBehaviour
{
    public Animator animator;

    [SerializeField] RoadLine roadLine;
    [SerializeField] RoadLine previousRoadLine;

    [SerializeField] float lerpSpeed = 25.0f;
    [SerializeField] float positionX = 2.25f;

    void Start()
    {
        roadLine = RoadLine.MIDDLE;
        previousRoadLine = RoadLine.MIDDLE;

        InputManager.instance.keyAction += Move;
    }

    void Update()
    {
        Status();
    }

    public void Move()
    {
        if (GameManager.instance.state == false) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (roadLine > RoadLine.LEFT)
            {
                animator.Play("Left Avoid");

                previousRoadLine = roadLine;

                roadLine--;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (roadLine < RoadLine.RIGHT)
            {
                animator.Play("Right Avoid");

                previousRoadLine = roadLine;

                roadLine++;
            }
        }
    }

    public void Status()
    {
        switch (roadLine)
        {
            case RoadLine.LEFT:
                Movement(-positionX);
                break;
            case RoadLine.MIDDLE:
                Movement(0);
                break;
            case RoadLine.RIGHT:
                Movement(positionX);
                break;
        }
    }

    public void RevertPosition()
    {
        roadLine = previousRoadLine;
    }

    public void Movement(float positionX)
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(positionX, 0, 0), lerpSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        CollisionObject collisionObject = other.GetComponent<CollisionObject>();

        if (collisionObject != null)
        {
            collisionObject.Activate(this);
        }
    }

    private void OnDisable()
    {
        InputManager.instance.keyAction -= Move;
    }

   
}
