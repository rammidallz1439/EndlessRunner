using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
public class ContextController : Registerer
{
    public override void OnAwake()
    {
        RegisterController(EventManager.Instance);
        //RegisterController(new PlayerController());
    }

    public override void OnStart()
    {
        
    }
}
