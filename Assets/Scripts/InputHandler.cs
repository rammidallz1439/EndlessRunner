using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private ICommand _moveRightCommad;
    private ICommand _moveLeftCommad;
    [SerializeField] private Player Player;
    // Start is called before the first frame update
    void Start()
    {
        _moveRightCommad = new MoveRightCommand(Player);
        _moveLeftCommad = new MoveLeftCommand(Player);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) { _moveRightCommad.Excute(); }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { _moveLeftCommad.Excute(); }
    }
}
