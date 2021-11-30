using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public int inventorySize;
    private int inventorySlot = 1;
    
    private List<Item> inventory = new List<Item>();

    //private List<Item> inventory = new List<Item>();
    private List<Item> Inventory1
    {
        get => inventory;
        set => inventory = value;
    }

    public void AddToInventory(Item item)
    {
        
            if (item.Stackable)
            {
                var result = inventory.Find(item => item.Amount == inventorySlot); // WTF is this...
                Debug.Log($"{item} : {item.Amount}");
            }

            if (!item.Stackable)
            {
                if (inventory.Count < inventorySize)
                {
                    inventory.Add(item);
                    inventorySlot++;
                    Debug.Log("added item");
                }
                if (inventory.Count > inventorySize)
                {
                    Debug.Log("inventory is full");
                }
            }
        
    }
}
