using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    public Vector3 moveDirection;
    public Vector2 mousePosition;
    public MoveCommand(Vector3 moveDir, Vector2 mousePos)
    {
        type = CommandType.Move;

        moveDirection = moveDir;
        mousePosition = mousePos;
    }
}
