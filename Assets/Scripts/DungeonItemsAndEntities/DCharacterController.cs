using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DCharacterController : MonoBehaviour, Damageable
{
    public DWeapon myWeapon;
    public float health = 100;

    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        myWeapon = this.gameObject.GetComponentInChildren<DWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExecuteCommand(Command command)
    {
        switch (command.type)
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
                break;

            case CommandType.Damage: //If for some reason I go through execute, this is here to catch me. ReceiveDamage is, for the moment, public to ensure that it can be casted on non CC objects.
                ReceiveDamage(command as DamageCommand);
                break;

            default:
                break;
        }
    }

    private void Move(MoveCommand command)
    {
        //Movement
        rb.velocity = command.moveDirection * moveSpeed;
        Vector2 lookDir = command.mousePosition - rb.position;
        rb.rotation = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
    }

    void ShootMyWeapon(ShootCommand command)
    {
        myWeapon.Shoot();//Is this necessary? Probably not, but i doubt it's gonna break things.
    }

    public void ReceiveDamage(DamageCommand command) 
    {
        //Debating whether this will bite me in the ass, but for now...
        if(command.damage < 0)
            this.HealDamage(command.damage * -1); //Negative damage will trigger healing on living beings.
        else
        {

        }
    }

    private void HealDamage(float incomingHeal)
    {

    }

    public void Die()
    {

    }
}
