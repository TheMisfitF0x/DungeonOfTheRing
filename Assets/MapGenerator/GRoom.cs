using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GRoom : MonoBehaviour
{
    // All openings in this prefab. Accumulated upon awakening
    private GDungeon dungeon;
    public List<GOpening> myOpenings = new List<GOpening>();

    // Game Object whose children are box colliders, iterate through these to determine if room valid.
    private List<GValidator> validators = new List<GValidator>();
    private RoomState roomState;
    private bool noMoreRooms = false;
    public void Awake()
    {
        dungeon = GameObject.Find("DungeonStart").GetComponent<GDungeon>();

        //Get all GOpenings (They are children)
        foreach(GOpening opening in gameObject.GetComponentsInChildren<GOpening>())
        {
            myOpenings.Add(opening);
        }

        //Get my colliders
        foreach (GValidator validator in gameObject.GetComponentsInChildren<GValidator>())
        {
            validators.Add(validator);
        }
        //Get the dungeon
    }

    public RoomState ValidateExistence()
    {
        //print("Checking" + validators.Count + " validators...");
        //Detect collisions, return RoomState.Valid if none, RoomState.Invalid otherwise
        foreach(GValidator validator in validators)
        {
            if(!validator.IsValid())
            {
                //print("Room Invalid here");
                return RoomState.Invalid;
            }
        }
        //print("Room Valid");
        return RoomState.Valid;
    }

    public void GenerateRoomsFromOpen()
    {
        print("Alright");
        //Iterates through myOpenings and populates each one with either a new room or a closing.
        foreach(GOpening opening in myOpenings)
        {
            print("New Opening");
            if (!noMoreRooms)
            {
                print("Go for it!");
                GRoom newRoom = opening.SpawnRoom();

                if (newRoom != null)
                {
                    print("Room Made! Are we done?");
                    if (dungeon.AddRoom(newRoom) == true)
                    {
                        print("Ok");
                        noMoreRooms = true;
                    }
                }
            }
            else
            {
                print("All done!");
                opening.Skip();
            }
        }
        print("Done with all openings");
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