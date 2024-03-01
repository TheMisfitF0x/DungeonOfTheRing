using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GRoom : MonoBehaviour
{
    // All openings in this prefab. Accumulated upon awakening
    private GDungeon dungeon;
    private GOpening myOpenings;

    // Game Object whose children are box colliders, iterate through these to determine if room valid.
    private List<Collider2D> validators;
    private RoomState roomState;

    public void Awake()
    {
        //Get all GOpenings
        //Get my colliders
        //Get the dungeon
    }

    public RoomState ValidateExistence()
    {
        //Detect collisions, return RoomState.Valid if none, RoomState.Invalid otherwise

        return RoomState.Valid;
    }

    public void GenerateRoomsFromOpen()
    {
        //Iterates through myOpenings and populates each one with either a new room or a closing.
        //Report each successful room to the Dungeon, and if at any point the dungeon says to stop, tell all remaining openings to only generate closings.
    }

    public void DestroyRoom()
    {
        Destroy(gameObject);
    }
}

public enum RoomState
{
    Valid,
    Invalid,
    Unknown
}