using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamScript : MonoBehaviour
{

    public GameObject object2Follow;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 targetPos = object2Follow.transform.position;
        this.transform.position = Vector2.MoveTowards(this.transform.position, targetPos, speed);
    }
}
