using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DRShield : DProjectile, Damageable
{
    // Start is called before the first frame update
    public float health;
    public float repluseStrength;
    

    private void OnTriggerEnter2D(Collider2D collision) //When I hit a thing
    {
        if (Time.time > timeAtSpawn + .1f && collision.GetComponent<DCharacterController>() != null)
        {
            ImpactDetonate(collision.GetComponent<DCharacterController>());
            print("Hit a guy");
        }
        else if (collision.gameObject.CompareTag("Wall") == true)
        {
            TimeOutDetonate();
        }
    }

    //Detonate types
    public void ImpactDetonate(DCharacterController target)
    {
        Vector2 direction = (target.transform.position - transform.position).normalized;
        target.ExecuteCommand(new RepulseCommand(direction, repluseStrength));
    }

    public override void TimeOutDetonate()
    {
        Destroy(gameObject);
    }

    public void ReceiveDamage(DamageCommand command)
    {
        health -= command.damage;
        if(health < 0)
        {
            health = 0;
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
