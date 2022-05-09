using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 25f;
    public float lifespan = 5f;

    private float timeAtSpawn;

    private void Awake()
    {
        timeAtSpawn = Time.time;
    }

    private void Update()
    {
        if(Time.time > timeAtSpawn + lifespan)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") == true || (collision.gameObject.CompareTag("Player") == true && Time.time > timeAtSpawn + .1f))
        {
            damageTarget(collision.gameObject.GetComponent<Damageable>());
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Wall")==true)
        {
            Destroy(gameObject);
        }
    }

    void damageTarget(Damageable objToDmg)
    {
        objToDmg.health -= damage;
    }
}
