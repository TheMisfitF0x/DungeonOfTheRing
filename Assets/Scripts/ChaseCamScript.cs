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
        Vector3 targetPos = new Vector3(object2Follow.transform.position.x, object2Follow.transform.position.y, -3);
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, speed);
    }
}
