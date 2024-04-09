using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDungeon : MonoBehaviour
{
    private List<GRoom> spawnedRooms;
    private GRoom startingRoom;
    public List<GameObject> spawnableRooms;
    public int roomsToSpawn;

    public void Start()
    {
        startingRoom = GetComponent<GRoom>();
        print(startingRoom);
        //InitMapGeneration();
    }

    public bool InitMapGeneration()
    {
        //Spawn the first room if none exists, then send a signal to that room (or the current starting room) to begin iterating through openings.
        startingRoom.GenerateRoomsFromOpen();
        return true;
    }

    public bool AddRoom(GRoom room2Add)
    {
        //Checks the provided room and the current dungeon statistics. If this is the last standard room, return true and run AddFinalRoom().
        //Else, return false to signal the room to spawn another room.
        spawnedRooms.Add(room2Add);
        if(spawnableRooms.Count == roomsToSpawn)
        {
            print("Yeah, we're done.");
            AddFinalRoom();
            return true;
        }
        else
        {
            print("Nah, keep going");
            return false;
        }
    }

    private bool AddFinalRoom()
    {
        //Iterate through the rooms added in reverse order (trying to grab one of the further rooms from the player) and try to add the exit room.
        //If it cannot be added at ny point, remove the last room and replace it with an exit room.
        return true;
    }
}
