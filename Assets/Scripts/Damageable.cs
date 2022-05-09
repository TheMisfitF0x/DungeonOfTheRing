using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float health = 50;

    // Update is called once per frame
    private void Update()
    {
        if(health <= 0f)
        {
            die();
        }
    }

    void die()
    {
        Destroy(gameObject);
    }
}