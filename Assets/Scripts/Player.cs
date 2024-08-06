using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public void MoveLeft()
    {
        EventManager.Instance.TriggerEvent(new MoveLeftEvent(transform));
    }

    public void MoveRight()
    {
        EventManager.Instance.TriggerEvent(new MoveRightEvent(transform));
    }


}
