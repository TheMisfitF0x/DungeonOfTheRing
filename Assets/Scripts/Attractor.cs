using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    //Gravity Constant
    float G = 5f;

    //To create attractors that ignore all attractions (to reduce the amount of calls made to the center of the room)
    public bool ignoreAttractions;

    //To prevent bullets from attracting each other unless designed to (black hole projectile)
    public bool attractsBullets;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; //Doublecheck, make sure unity isn't being mean to me.
    }

    void FixedUpdate()
    {
        //Get all attractors
        Attractor[] attractors = FindObjectsOfType<Attractor>();

        //For every attractor, check if should attract, then attract
        foreach(Attractor attractor in attractors)
        {
            if (attractor != this && attractor.ignoreAttractions == false && attractor.enabled)
            {
                //If this attractor attracts bullets or the object is not a bullet, attract it.
                if ((attractor.CompareTag("Projectile") && this.attractsBullets) || !attractor.CompareTag("Projectile"))
                    Attract(attractor);
            }
        }

        if(!rb.gameObject.GetComponent<DCharacterController>())
            rb.rotation = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
    }

    void Attract(Attractor objToAttract)
    {
        Rigidbody2D rbToAttract = objToAttract.rb;
        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.sqrMagnitude;

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / distance;

        Vector3 force = direction.normalized * forceMagnitude;
        rbToAttract.AddForce(force);
    }

    
}
