using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Weapon weapon;
    public GameObject weaponPoint;

    private float lastWeaponPickup = 0f;
    private float weaponPickupDelay =  .5f;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Weapon")==true)
        {
            if(collision.gameObject.GetComponent<Weapon>().isPickedUp == false && Time.time >= lastWeaponPickup + weaponPickupDelay)
            {
                pickupWeapon(collision.gameObject);
            }
        }
    }

    private void pickupWeapon(GameObject weaponToPickup)
    {
        weaponToPickup.transform.SetParent(weaponPoint.transform);

        if(weapon != null)
        {
            dropWeapon();
        }

        weapon = weaponToPickup.GetComponent<Weapon>();

        weapon.transform.SetPositionAndRotation(weaponPoint.transform.position, weaponPoint.transform.rotation);
    }

    private void dropWeapon()
    {
        weapon.transform.SetParent(null);
        weapon = null;
        lastWeaponPickup = Time.time;
    }
}
