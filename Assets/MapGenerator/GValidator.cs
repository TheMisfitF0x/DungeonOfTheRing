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
        Collider2D[] overlappingColliders = new Collider2D[100];
        thisCollider.OverlapCollider(new ContactFilter2D().NoFilter(), overlappingColliders);

        print(overlappingColliders);
        foreach (Collider2D collider in overlappingColliders)
        {
            print(collider);

            if (collider == null)
                break;

            if (collider.CompareTag("Wall") == true || collider.CompareTag("Validator") == true)
            {
                return false;
            }
        }

        return true;
    }
}
