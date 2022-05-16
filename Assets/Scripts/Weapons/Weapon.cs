using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    public float muzzleVelocity;
    public Transform muzzle;
    public bool canHoldTrigger;
    public float fireDelay;

    private float lastShotTime = 0;


    public void Shoot()
    {
        if (Time.time >= lastShotTime + fireDelay)
        {
            GameObject bullet = Instantiate(projectile, muzzle.position, muzzle.rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(muzzle.up * muzzleVelocity, ForceMode2D.Impulse);

            lastShotTime = Time.time;
        }
    }
}
