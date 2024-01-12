using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{

    public Action keyAction; 

    
    void Update()
    {
        // Input.anyKey : KEY 입력이 들어오지 않은 상태이면
        if (Input.anyKey ==false)
        {
            return;
        }
        
        if(keyAction !=null)
        {
            keyAction.Invoke();
        }
    }
}
