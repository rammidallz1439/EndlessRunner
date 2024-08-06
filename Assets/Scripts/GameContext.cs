using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
public class GameContext : Registerer
{
    [SerializeField] private PlayerHandler _playerHandler;
    public override void OnAwake()
    {
        RegisterController(new PlayerController(_playerHandler));
    }

    public override void OnStart()
    {
    }
}
