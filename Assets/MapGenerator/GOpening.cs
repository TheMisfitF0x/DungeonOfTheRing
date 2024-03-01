using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOpening : MonoBehaviour
{
    public GRoom connectedRoom;
    public OpeningConnection connectionState;
    private List<GRoom> spawnableRooms; 

    public void Awake()
    {
        //Get the list of spawnable rooms from assets or the dungeon
    }

    public bool SpawnRoom()
    {
        //Generate a random int within the indecies of the current spawnable list
        //Attempt to the room and have it self-validate
        //If it fails, order it to KILL ITSELF and try the next index, wrapping back around if need be.
        //If it successfully builds a room, return true. Else if it goes through the whole list without success return false.
        return true;
    }
}

public enum OpeningConnection
{
    Door,
    Wall,
    None
}
