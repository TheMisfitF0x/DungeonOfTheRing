using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    public Vector3 moveDirection;
    public MoveCommand(Vector3 direction)
    {
        type = CommandType.Move;

        moveDirection = direction;
    }
}
