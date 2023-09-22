using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    float angle = 0f;
    const float DISTANCE = 5f;

    // Start is called before the first frame update
    void Start()
    {
        float startingX = Mathf.Cos(angle) * DISTANCE;
        float startingY = Mathf.Sin(angle) * DISTANCE;
        this.gameObject.transform.position = new Vector2(startingX, startingY);
    }

    // Update is called once per frame
    void Update()
    {
        angle += .005f;

        float newX = Mathf.Cos(angle) * DISTANCE;
        float newY = Mathf.Sin(angle) * DISTANCE;

        this.gameObject.transform.position = new Vector2(newX, newY);
    }
}
