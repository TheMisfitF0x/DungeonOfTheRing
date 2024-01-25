using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DCharacterController : MonoBehaviour, Damageable
{
    private DWeapon myWeapon;
    private float health;

    // Start is called before the first frame update
    void Start()
    {
        
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
            case CommandType.Damage:
                ReceiveDamage(command as DamageCommand);
        }
    }

    private void Move(MoveCommand command)
    {
        
    }

    void ShootMyWeapon(ShootCommand command)
    {
        if (isFullAuto)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                //Start Firing
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                //Stop Firing
            }
            
        }
        else
        {
            myWeapon.Shoot();
        }
    }

    public void ReceiveDamage(ShootCommand command) 
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
