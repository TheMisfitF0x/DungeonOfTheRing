using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DShotgun : DWeapon
{
    //Rounds fired per valid trigger pull
    public int projectileCount = 3;

    //True if rounds are to be evenly spaced within the spread
    public bool uniformDistroAngle = false;

    //In degrees
    public float spread = 40;
    public override void Shoot()
    {
        if (Time.time >= lastShotTime + fireDelay)
        {
            for (int i = 0; i < projectileCount; i++)
            {
                // Calculate the spread angle for each pellet
                float angle = transform.eulerAngles.z - spread / 2 + Random.Range(0f, spread);

                // Create a new pellet instance
                GameObject pellet = Instantiate(projectile, transform.position, Quaternion.Euler(0f, 0f, angle));

                // Apply force to the pellet
                Rigidbody2D rb = pellet.GetComponent<Rigidbody2D>();
                rb.velocity = pellet.transform.up * muzzleVelocity;
            }

            lastShotTime = Time.time;
        }
    }
}
