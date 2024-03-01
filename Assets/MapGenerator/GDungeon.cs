using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDungeon : MonoBehaviour
{
    private List<GRoom> spawnedRooms;

    public int roomsToSpawn;

    public bool InitMapGeneration()
    {
        //Spawn the first room if none exists, then send a signal to that room (or the current starting room) to begin iterating through openings.


        return true;
    }

    public bool AddRoom(GRoom room2Add)
    {
        //Checks the provided room and the current dungeon statistics. If this is the last standard room, return true and run AddFinalRoom().
        //Else, return false to signal the room to spawn another room.

        return true;
    }

    private bool AddFinalRoom()
    {
        //Iterate through the rooms added in reverse order (trying to grab one of the further rooms from the player) and try to add the exit room.
        //If it cannot be added at ny point, remove the last room and replace it with an exit room.
        return true;
    }

    private void CloseEmptyOpenings()
    {
        //Iterate through the dungeon and close every unconnected opening with a wall.
        
    }
}
