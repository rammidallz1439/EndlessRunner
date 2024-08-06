using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
using System;

public class PlayerController : PlayerManager, IController,IFixedTick,ITick
{

    public PlayerController(PlayerHandler handler)
    {
        Handler = handler;
    }

    public void OnInitialize()
    {

    }

    public void OnFixedUpdate()
    {
       
        Handler.Rb.velocity = new Vector3(0, 0, Handler.speed) * Time.deltaTime;
        EventManager.Instance.TriggerEvent(new SpawnPlatformEvent(Handler.player, () => { }));
    }

    public void RegisterListener()
    {
        EventManager.Instance.AddListener<SpawnPlatformEvent>(SpawnPlatformEventHandler);
        EventManager.Instance.AddListener<MoveRightEvent>(MoveRightEventHandler);
        EventManager.Instance.AddListener<MoveLeftEvent>(MoveLeftEventHandler);
        EventManager.Instance.AddListener<PlayerJumpEvent>(PlayerJumpEventHandler);
    }



    public void RemoveListener()
    {
        EventManager.Instance.RemoveListener<SpawnPlatformEvent>(SpawnPlatformEventHandler);
        EventManager.Instance.RemoveListener<MoveRightEvent>(MoveRightEventHandler);
        EventManager.Instance.RemoveListener<MoveLeftEvent>(MoveLeftEventHandler);
        EventManager.Instance.RemoveListener<PlayerJumpEvent>(PlayerJumpEventHandler);

    }

    public void Release()
    {

    }

    public void OnUpdate()
    {
        
        EventManager.Instance.TriggerEvent(new PlayerJumpEvent());
    }
}

