using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DProjectile : MonoBehaviour
{
    public float damage = 25f;
    public float lifespan = 5f;

    protected float timeAtSpawn;

    private void Awake()
    {
        timeAtSpawn = Time.time;
    }

    private void Update()
    {
        if (Time.time > timeAtSpawn + lifespan)
        {
            TimeOutDetonate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //When I hit a thing
    {
        if (Time.time > timeAtSpawn + .1f && collision.GetComponent<Damageable>() != null)
        {
            ImpactDetonate(collision.GetComponent<Damageable>());
        }
        else if (collision.gameObject.CompareTag("Wall") == true)
        {
            TimeOutDetonate();
        }
    }

    //Detonate types
    public virtual void ImpactDetonate(Damageable target)
    {
        target.ReceiveDamage(new DamageCommand(damage, Vector3.zero));
        Destroy(gameObject);
    }

    public virtual void TimeOutDetonate()
    {
        Destroy(gameObject);
    }

    public virtual void SecondaryFireDetonate()
    {
        //There is nothing for this guy.
    }
}
