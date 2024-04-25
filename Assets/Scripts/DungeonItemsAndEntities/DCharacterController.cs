using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DCharacterController : MonoBehaviour, Damageable
{
    public DWeapon myWeapon;
    public GameObject deathEffect;
    public float health = 100;

    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private UIManager uiMan;
    private Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        //Find all the things.
        rb = this.GetComponent<Rigidbody2D>();
        uiMan = GameObject.Find("UIManager").GetComponent<UIManager>();
        myWeapon = this.gameObject.GetComponentInChildren<DWeapon>();
        if (this.CompareTag("Enemy")) healthBar = this.transform.Find("Canvas").Find("HealthBar").GetComponent<Slider>(); //If enemy, grab the local healthbar
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExecuteCommand(Command command)
    {
        switch (command.type)//Upon receiving a command, check itss type and route to the appropriate method.
        {
            case CommandType.Move:
                Move(command as MoveCommand);
                break;

            case CommandType.Ability:
                break;

            case CommandType.Shoot:
                ShootMyWeapon(command as ShootCommand);
                break;

            case CommandType.Repulse:
                Repulse(command as RepulseCommand);
                break;

            case CommandType.Damage: //If for some reason I go through execute, this is here to catch me. ReceiveDamage is, for the moment, public to ensure that it can be casted on non CC objects.
                ReceiveDamage(command as DamageCommand);
                break;
            case CommandType.Interact:
                InteractWith(command as InteractCommand);
                break;

            default:
                break;
        }
    }

    public void Repulse(RepulseCommand command)
    {
        print("Triggering Repulse");
        rb.AddForce(command.pulseDirection * command.pulseStrength, ForceMode2D.Impulse);
    }

    private void Move(MoveCommand command)
    {
        //Set velocity to direction at speed
        Attractor attractor = GetComponent<Attractor>();
        if (attractor == null || !attractor.enabled)
            rb.velocity = command.moveDirection * moveSpeed;

        //Rotate the character to look at the mouse on the screen.


        Vector2 lookDir = command.mousePosition - rb.position;
        if (this.CompareTag("Player"))
            rb.rotation = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        else if(this.CompareTag("Enemy"))
        {
            Transform myBody = this.transform.GetChild(1);
            Vector3 direction = command.mousePosition - new Vector2(myBody.transform.position.x, myBody.transform.position.y);

            // Calculate the angle in degrees
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            angle += 90f;

            // Set the rotation of the sprite to face the target object
            myBody.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    

    void ShootMyWeapon(ShootCommand command)
    {
        if (myWeapon != null)
        {
            if (!command.isSecondaryFire) myWeapon.Shoot();
            else myWeapon.AltShoot();
        }//Is this necessary? Probably not, but i doubt it's gonna break things.
    }

    public void ReceiveDamage(DamageCommand command) 
    {
        //Debating whether this will bite me in the ass, but for now...
        if(command.damage < 0)
            this.HealDamage(command.damage * -1); //Negative damage will trigger healing on living beings.
        else
        {
            health -= command.damage;
        }

        if (this.CompareTag("Player")) uiMan.setPlayerHealth(health); //If a player, inform the UIManager to update special Health Bar
        else if (this.CompareTag("Enemy")) healthBar.value = health; //If an enemy, update the local health slider.

        if (health <= 0) Die();
    }

    private void HealDamage(float incomingHeal)
    {
        //Do the healy thing. For now...
        health += incomingHeal;
    }

    private void InteractWith(InteractCommand command)
    {
        if(command.item is DWeapon)
        {
            DWeapon groundWeapon = (DWeapon)command.item;
            if(myWeapon != null)
            {
                myWeapon.holdingCharacter = null;
                myWeapon.transform.parent = null;
                myWeapon.transform.position = groundWeapon.transform.position;
                myWeapon.transform.rotation = groundWeapon.transform.rotation;
            }
            myWeapon = groundWeapon;
            groundWeapon.Interact(this);
        }
            
    }

    public void Die()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject); //Simple and easy remove for now.
    }
}
