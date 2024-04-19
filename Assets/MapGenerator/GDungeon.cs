using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDungeon : MonoBehaviour
{
    private List<GRoom> spawnedRooms;
    public List<GameObject> spawnableRooms;
    public int roomsToSpawn;

    public void Start()
    {
        spawnedRooms.Add(GetComponent<GRoom>());
        
    }

    public bool GenerateMap()
    {
 
        int currentRoomIndex = 0;


        do {
            spawnedRooms[currentRoomIndex].GenerateRoomsFromOpen();
            currentRoomIndex++;
        } while (currentRoomIndex < spawnedRooms.Count);
        
        return true;
    }

    public bool AddRoom(GRoom room2Add)
    {
        //Checks the provided room and the current dungeon statistics. If this is the last standard room, return true and run AddFinalRoom().
        //Else, return false to signal the room to spawn another room.
        spawnedRooms.Add(room2Add);
        if(spawnedRooms.Count >= roomsToSpawn)
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
