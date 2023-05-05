using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoEnemyBehavior : MonoBehaviour
{

    private GameObject player;

    private List<string> states = new List<string>();
    private string currentState;


    void Start()
    {
        states.AddRange(new string[] { "Moving", "Aiming", "Shooting" });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
