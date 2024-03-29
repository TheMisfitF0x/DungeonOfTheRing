using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCommand : Command
{
    public bool isSecondaryFire;
    public ShootCommand(bool isSecondaryFire)
    {
        type = CommandType.Shoot;
        this.isSecondaryFire = isSecondaryFire;
    }
}
