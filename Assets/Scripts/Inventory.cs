using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxItems = 2;
    private List<string> items = new List<string>();

    public void addToInventory(string item)
    {
        if(items.Count < maxItems)
        {
            items.Add(item);
            Debug.Log("Item added: " + item);
        }
        else
        {
            Debug.Log("Inventory full. Cannot add item: " + item);
        }
    }
    public void removeFromInventory(string item)
    {
        if(items.Contains(item))
        {
            items.Remove(item);
            Debug.Log("Item removed: " + item);
        }
        else
        {
            Debug.Log("Item not found in inventory: " + item);
        }
    }
}
