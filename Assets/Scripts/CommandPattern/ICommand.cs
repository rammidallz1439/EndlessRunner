using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    public void Excute();
}

public class MoveRightCommand : ICommand
{
    private Player player;

    public MoveRightCommand(Player player)
    {
        this.player = player;
    }

    public void Excute()
    {
        player.MoveRight();
    }
}

public class MoveLeftCommand : ICommand
{
    private Player player;
    public MoveLeftCommand(Player player)
    {
        this.player = player;
    }
    public void Excute()
    {
        player.MoveLeft();
    }
}