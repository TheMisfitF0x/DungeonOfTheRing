using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOpening : MonoBehaviour
{
    public OpeningConnection connectionState = OpeningConnection.None;
    public OpeningDirection openingDirection;
    public GameObject closingPrefab;

    private OpeningDirection desiredDirection;
    private GRoom myRoom;
    private List<GameObject> spawnableRooms;
    
    public void Awake()
    {
        //Get the list of spawnable rooms from assets or the dungeon
        spawnableRooms = GameObject.Find("DungeonStart").GetComponent<GDungeon>().spawnableRooms;
        myRoom = GetComponentInParent<GRoom>();

        switch(openingDirection)
        {
            case OpeningDirection.East:
                desiredDirection = OpeningDirection.West;
                break;
            case OpeningDirection.West:
                desiredDirection = OpeningDirection.East;
                break;
            case OpeningDirection.North:
                desiredDirection = OpeningDirection.South;
                break;
            case OpeningDirection.South:
                desiredDirection = OpeningDirection.North;
                break;
        }
    }

    public GRoom SpawnRoom()
    {
        print("Ok, here I go!");
        print("I am a " + openingDirection + "-facing opening");
        bool allRoomsTried = false;
        //Select a random index within length
        // Generate a random index within the range of the list length
        int randomIndex = Random.Range(0, spawnableRooms.Count);
        print("Picked a starting point");
        int initialIndex = randomIndex;
        while (!allRoomsTried)
        {
            GRoom newRoom = Instantiate(spawnableRooms[randomIndex]).GetComponent<GRoom>();
            print("New Room Created!");
            List<GOpening> newOpenings = newRoom.myOpenings;
            print(newOpenings.Count);

            foreach (GOpening newOpening in newOpenings)
            {
                if (newOpening.openingDirection == desiredDirection)
                {
                    // Calculate the position and rotation of the next room relative to the current room
                    Vector3 offset = newOpening.transform.position - this.transform.position;
                    print(offset);
                    // Position and rotate the next room
                    newRoom.transform.position = myRoom.transform.position + offset;

                    if (newRoom.ValidateExistence() == RoomState.Valid)
                    {
                        print("Welcome to the dungeon!");
                        return newRoom;
                    }
                    else
                        print("Bad Opening");
                }
                else
                    print("Opening facing wrong direction");
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
            newRoom.DestroyRoom();
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

public enum OpeningDirection
{
    East,
    West,
    North,
    South
}
