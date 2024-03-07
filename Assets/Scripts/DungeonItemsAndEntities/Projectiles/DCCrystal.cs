using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DCCrystal : DProjectile
{
    //Force that the impact detonation exerts on projectiles and enemies. 
    public float repulseForce = 100f;
    public bool forceScalesWithDistance = true;
    public Collider2D repulseRadius;

    public override void ImpactDetonate(Damageable target)
    {
        target.ReceiveDamage(new DamageCommand(damage, Vector3.zero));
        TimeOutDetonate();
    }

    public override void TimeOutDetonate()
    {
        repulseRadius.enabled = true;
        // Find all colliders overlapping with this collider and filter by tag
        Collider2D[] overlappingColliders = new Collider2D[100];
        repulseRadius.OverlapCollider(new ContactFilter2D().NoFilter(), overlappingColliders);

        print(overlappingColliders);
        foreach (Collider2D collider in overlappingColliders)
        {
            print(collider);

            if(collider == null)
            {
                break;
            }

            if (collider.CompareTag("Projectile") || collider.CompareTag("Enemy") || collider.CompareTag("Player"))
            {
                print("Found a thing to push");
                // Calculate direction away from the center of the first collider
                Vector2 direction = (collider.transform.position - transform.position).normalized;

                // Calculate distance-based force magnitude
                float distance = Vector2.Distance(transform.position, collider.transform.position);

                //Unused for the moment while tweaking happens
                float force = Mathf.Clamp(repulseForce / distance, 0f, repulseForce);

                // Apply force to the overlapping collider
                Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    print("Pushing");
                    rb.AddForce(direction * repulseForce, ForceMode2D.Impulse);
                }
            }
            
        }
        Destroy(gameObject);
    }
}
