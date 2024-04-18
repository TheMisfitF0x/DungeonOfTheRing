using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DProjectile : MonoBehaviour
{
    public float damage = 25f;
    public float lifespan = 5f;

    private Vector2 startingPos;
    private bool isOutOfGun;

    protected float timeAtSpawn;

    private void Awake()
    {
        timeAtSpawn = Time.time;
        startingPos = transform.position;
    }

    private void Update()
    {
        if (!isOutOfGun && Vector2.Distance(startingPos, transform.position) >= .00005f)
            isOutOfGun = true;
        if (Time.time > timeAtSpawn + lifespan)
        {
            TimeOutDetonate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //When I hit a thing
    {
        if (isOutOfGun && collision.GetComponent<Damageable>() != null)
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
