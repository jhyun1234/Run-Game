using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleDetctor : CollisionObject
{
    public override void Activate(Runnrer runnrer)
    {
        runnrer.ReverPosition();
        
    }
}
