using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsController
{
    
}

public class PlayerSavePositionEvent : GameEvent
{
    public Vector3 playerPosition;
    public Action<PlayerManager> onfinish;

    public PlayerSavePositionEvent(Vector3 playerPosition, Action<PlayerManager> onfinish)
    {
        this.playerPosition = playerPosition;
        this.onfinish = onfinish;
    }
}
public struct SpawnPlatformEvent : GameEvent
{
    public GameObject player;
    public Action onfinish;

    public SpawnPlatformEvent(GameObject player,Action onfinish)
    {
        this.player = player;
        this.onfinish = onfinish;
    }
}

public struct PlatformReturningEvent : GameEvent
{

}


public struct MoveRightEvent : GameEvent
{
    public Transform Player;

    public MoveRightEvent(Transform player)
    {
        Player = player;
    }
}

public struct MoveLeftEvent : GameEvent
{
    public Transform Player;

    public MoveLeftEvent(Transform player)
    {
        Player = player;
    }
}

public struct PlayerJumpEvent : GameEvent
{

}
