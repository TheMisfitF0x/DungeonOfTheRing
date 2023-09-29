using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> items = new List<Item>(); // List to hold the items.

    // Add an item to the inventory.
    public void AddItem(Item item)
    {
        items.Add(item);
    }

    // Remove an item from the inventory.
    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    // Check if the inventory contains a specific item.
    public bool ContainsItem(Item item)
    {
        return items.Contains(item);
    }

    // Get a copy of the inventory as a list.
    public List<Item> GetItems()
    {
        return new List<Item>(items);
    }

    // Clear all items from the inventory.
    public void ClearInventory()
    {
        items.Clear();
    }
}