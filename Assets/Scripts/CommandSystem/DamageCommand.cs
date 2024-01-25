using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCommand : Command
{
    public float damage;
    public Vector3 knockbackImpulse;
    public DamageCommand(float damage, Vector3 knockbackImpulse)
    {
        type = CommandType.Damage;

        this.damage = damage;
        this.knockbackImpulse = knockbackImpulse;
    }
}
