using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Weapon weapon;

    bool holdingTrigger = false;

    // Update is called once per frame
    void Update()
    {
        if(weapon.canHoldTrigger)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                holdingTrigger = true;
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                holdingTrigger = false;
            }

            if(holdingTrigger)
            {
                weapon.Shoot();
            }
        }
        else
        {
            if(Input.GetButtonDown("Fire1"))
            {
                weapon.Shoot();
            }
        }
    }
}
