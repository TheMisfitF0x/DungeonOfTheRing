using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DWeapon : MonoBehaviour
{
    public GameObject projectile;
    public float muzzleVelocity;
    private Transform muzzlePoint;
    public bool canHoldTrigger;
    public float fireDelay;
    public bool isPickedUp = false;


    protected float lastShotTime = 0;
    protected Collider2D pickupRadius;
    private void Start()
    {
        muzzlePoint = transform.Find("MuzzlePoint");
    }

    public virtual void Shoot()
    {
        Debug.Log("Shooting from standard prefab");
        if (Time.time >= lastShotTime + fireDelay)
        {
            GameObject bullet = Instantiate(projectile, muzzlePoint.position, muzzlePoint.rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(muzzlePoint.up * muzzleVelocity, ForceMode2D.Impulse);

            lastShotTime = Time.time;
        }
    }
}
