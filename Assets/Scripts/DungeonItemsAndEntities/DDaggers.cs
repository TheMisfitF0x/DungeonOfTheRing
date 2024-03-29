using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDaggers : DWeapon
{
    public override void AltShoot()
    {
        Attractor attractor = holdingCharacter.GetComponent<Attractor>();
        if(attractor != null)
        {
            if(!attractor.enabled)
            {
                attractor.enabled = true;
            }
            else
            {
                attractor.enabled = false;
            }
        }
        else
        {
            attractor = holdingCharacter.gameObject.AddComponent<Attractor>();
        }
    }
}
