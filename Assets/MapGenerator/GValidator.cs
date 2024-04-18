using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GValidator : MonoBehaviour
{
    Collider2D thisCollider;
    public void Awake()
    {
        thisCollider = GetComponent<Collider2D>();
    }

    public bool IsValid()
    {
        print("FUCK");
        Collider2D[] overlappingColliders = new Collider2D[100];
        thisCollider.OverlapCollider(new ContactFilter2D().NoFilter(), overlappingColliders);

        
        foreach (Collider2D collider in overlappingColliders)
        {
            if (collider == null)
                continue;

            if (collider.CompareTag("Validator") == true && collider != thisCollider)
            {
                print("Found " + collider.ToString());
                return false;
            }
        }

        return true;
    }
}
