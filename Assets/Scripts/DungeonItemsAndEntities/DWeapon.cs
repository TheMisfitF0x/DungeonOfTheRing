using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DWeapon : MonoBehaviour
{
    public GameObject projectile;
    public float muzzleVelocity;
    public Transform muzzle;
    public bool canHoldTrigger;
    public float fireDelay;
    public bool isPickedUp = false;


    protected float lastShotTime = 0;
    protected Collider2D pickupRadius;

    public virtual void Shoot()
    {
        Debug.Log("Shooting from standard prefab");
        if (Time.time >= lastShotTime + fireDelay)
        {
            GameObject bullet = Instantiate(projectile, muzzle.position, muzzle.rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(muzzle.up * muzzleVelocity, ForceMode2D.Impulse);

            lastShotTime = Time.time;
        }
    }
}
