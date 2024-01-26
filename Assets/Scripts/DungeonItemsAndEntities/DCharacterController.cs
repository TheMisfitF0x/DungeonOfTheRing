using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DCharacterController : MonoBehaviour, Damageable
{
    public DWeapon myWeapon;
    public float health = 100;

    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private UIManager uiMan;
    private Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        uiMan = GameObject.Find("UIManager").GetComponent<UIManager>();
        myWeapon = this.gameObject.GetComponentInChildren<DWeapon>();
        if (this.CompareTag("Enemy")) healthBar = this.transform.Find("Canvas").Find("HealthBar").GetComponent<Slider>();
        print(healthBar);
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
        if(myWeapon != null) myWeapon.Shoot();//Is this necessary? Probably not, but i doubt it's gonna break things.
    }

    public void ReceiveDamage(DamageCommand command) 
    {
        //Debating whether this will bite me in the ass, but for now...
        if(command.damage < 0)
            this.HealDamage(command.damage * -1); //Negative damage will trigger healing on living beings.
        else
        {
            health -= command.damage;
            if (this.CompareTag("Player")) uiMan.setPlayerHealth(health); //If a player, inform the UIManager to update special Health Bar
            else if (this.CompareTag("Enemy")) healthBar.value = health; //If an enemy, update the local health slider.
        }

        if (health <= 0) Die();
    }

    private void HealDamage(float incomingHeal)
    {

    }

    public void Die()
    {
        Destroy(gameObject); //Simple and easy remove for now.
    }
}
