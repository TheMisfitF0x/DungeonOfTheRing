using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOpening : MonoBehaviour
{
    public OpeningConnection connectionState = OpeningConnection.None;
    private GRoom myRoom;
    private List<GameObject> spawnableRooms;
    
    public void Awake()
    {
        //Get the list of spawnable rooms from assets or the dungeon
        spawnableRooms = GameObject.Find("DungeonStart").GetComponent<GDungeon>().spawnableRooms;
        myRoom = GetComponentInParent<GRoom>();
    }

    public GRoom SpawnRoom()
    {
        print("Ok, here I go!");
        bool allRoomsTried = false;
        //Select a random index within length
        // Generate a random index within the range of the list length
        int randomIndex = Random.Range(0, spawnableRooms.Count);
        print("Picked a starting point");
        int initialIndex = randomIndex;
        while (!allRoomsTried)
        {
            GRoom newRoom = Instantiate(spawnableRooms[randomIndex], this.transform.position, this.transform.rotation).GetComponent<GRoom>();
            print("New Room Created!");
            List<GOpening> newOpenings = newRoom.myOpenings;
            print(newOpenings.Count);

            foreach (GOpening newOpening in newOpenings)
            {
                // Calculate the position and rotation of the next room relative to the current room
                Vector3 offset = newOpening.transform.position - this.transform.position;
                Quaternion rotationOffset = Quaternion.FromToRotation(newOpening.transform.right, -this.transform.right);

                // Position and rotate the next room
                newRoom.transform.position = myRoom.transform.position + offset;
                newRoom.transform.rotation = myRoom.transform.rotation * rotationOffset;

                if (newRoom.ValidateExistence() == RoomState.Valid)
                {
                    print("Welcome to the dungeon!");
                    return newRoom;
                }
                else
                    print("Bad Opening");
            }
            randomIndex++;
            if(randomIndex == spawnableRooms.Count)
            {
                randomIndex = 0;
            }

            if(randomIndex == initialIndex)
            {
                allRoomsTried = true;
            }
            print("This room doesn't work...");
            Destroy(newRoom);
        }
        print("No room appears to work here...");
        return null;
    }

    public void Skip()
    {
        //Does nothing, opening is skipped so that the room can proceed. Leaving this open in case I decide I need to report back somehow.
    }
}

public enum OpeningConnection
{
    Door,
    Wall,
    None
}
