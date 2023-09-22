using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    //Rounds fired per valid trigger pull
    public int projectilesPerShot = 1;

    //True if rounds are to be evenly spaced within the spread
    public bool uniformDistroAngle = false;

    //In degrees
    public float spread = 40;
    public override void Shoot()
    {
        if (Time.time >= lastShotTime + fireDelay)
        {
            for (int i = -1; i < projectilesPerShot -1; i++)
            {
                Vector3 exitAngle = new Vector3(i,0,0);
                exitAngle = muzzle.InverseTransformVector(exitAngle);
                if (uniformDistroAngle)
                {
                    
                }
                else
                {

                }
                GameObject bullet = Instantiate(projectile, muzzle.position, muzzle.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                Debug.Log(muzzle.up + exitAngle);
                rb.AddForce((muzzle.up + exitAngle) * muzzleVelocity, ForceMode2D.Impulse);
            }

            lastShotTime = Time.time;
        }
    }
}
