using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProto : MonoBehaviour
{

    public Rigidbody2D rb;

    Vector3 bulletForce = new Vector3(-50, 100);
    void Awake()
    {
        rb.AddForce(bulletForce);
    }
}
