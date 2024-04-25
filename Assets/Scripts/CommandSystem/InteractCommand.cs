using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCommand : Command
{
    public Interactable item;
    public InteractCommand(Interactable item)
    {
        type = CommandType.Interact;
        this.item = item;
    }
}