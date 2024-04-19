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
            if(!IsValid(validator))
            {
                //print("Room Invalid here");
                roomState = RoomState.Invalid;
                return RoomState.Invalid;
            }
        }
        //print("Room Valid");
        roomState = RoomState.Valid;
        return RoomState.Valid;
    }

    public void GenerateRoomsFromOpen()
    {
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
                print("Skipped Opening");
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


    //--------Validator Commands...--------------------------------


    public bool IsValid(GValidator validator)
    {
        Collider2D[] overlappingColliders = new Collider2D[100];
        Collider2D thisCollider = validator.GetComponent<Collider2D>();
        thisCollider.OverlapCollider(new ContactFilter2D().NoFilter(), overlappingColliders);


        foreach (Collider2D collider in overlappingColliders)
        {
            if (collider == null)
                continue;

            if (collider.CompareTag("Validator") == true && collider != thisCollider && !validators.Contains(validator))
            {
                print("Found " + collider.ToString());
                return false;
            }
        }

        return true;
    }
}

public enum RoomState
{
    Valid,
    Invalid,
    Unknown
}