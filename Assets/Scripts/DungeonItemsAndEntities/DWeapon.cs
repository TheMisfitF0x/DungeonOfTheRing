using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DWeapon : MonoBehaviour, Interactable
{
    public GameObject projectile;
    public float muzzleVelocity;
    protected Transform muzzlePoint;
    protected AudioSource fireSound;
    public Animator groundAnim;
    public bool canHoldTrigger;
    public float fireDelay;
    public DCharacterController holdingCharacter;


    protected float lastShotTime = 0;
    protected Collider2D pickupRadius;
    private void Start()
    {
        muzzlePoint = transform.Find("MuzzlePoint");
        groundAnim = GetComponent<Animator>();
        fireSound = GetComponent<AudioSource>();
        if(holdingCharacter == null)
        {
            groundAnim.SetTrigger("Drop");
        }
    }

    

    public virtual void Shoot()
    {
        Debug.Log("Shooting from standard prefab");
        if (Time.time >= lastShotTime + fireDelay)
        {
            GameObject bullet = Instantiate(projectile, muzzlePoint.position, muzzlePoint.rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(muzzlePoint.up * muzzleVelocity, ForceMode2D.Impulse);
            fireSound.Play();
            lastShotTime = Time.time;
        }
    }

    public virtual void AltShoot()
    {
        //Overridable for future weapons
    }

    public void Interact(DCharacterController interactingActor)
    {
        Transform weaponSpot = interactingActor.transform.GetChild(0);
        
        this.transform.parent = interactingActor.gameObject.transform;
        this.transform.position = weaponSpot.position;
        this.transform.rotation = weaponSpot.rotation;
        holdingCharacter = interactingActor;
        groundAnim.SetTrigger("Pickup");
    }
}
