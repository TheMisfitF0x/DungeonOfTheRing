using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepulseCommand : Command
{//Command to apply an impulse to an entity over time. This can and should be used over a damage command w/ KB in most cases that aren't generic damage KB.
    //Specifically designed for repulsor shield but most certainly can apply elsewhere.
    public Vector3 pulseDirection;
    public float pulseStrength;
    public float pulseDurationMS; //Duration of the impulse in milliseconds. 0 basically stands for an instant shove. 
    public RepulseCommand(Vector3 direction, float strength)
    {
        type = CommandType.Repulse;

        pulseDirection = direction;
        pulseStrength = strength;
    }
}
