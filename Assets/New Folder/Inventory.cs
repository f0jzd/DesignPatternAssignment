using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Inventory : MonoBehaviour
{

    public int inventorySize;
    private int inventorySlot = 1;

    //private List<Item> inventory = new List<Item>();
    private List<Item> Inventory1 { get; } = new List<Item>();

    public void AddToInventory(Item item)
    {
        
        if (!Inventory1.Contains(item) && Inventory1.Count<inventorySize)
        {
            Debug.Log($"Adding {item} to inventory");
            Inventory1.Add(item);
            return;
        }
        
        if (item.stackable)
        {
            var amountToAdd = item.amount;
            
            var result = Inventory1.Find(item => item);

            result.amount += amountToAdd;
            
            Debug.Log($"Item : {item} , Amount: {result.amount}");
            
        }
        if (Inventory1.Contains(item) && !item.stackable)
        {
            if (Inventory1.Count < inventorySize)
            {
                Inventory1.Add(item);
                inventorySlot++;
                Debug.Log("added item");
            }

            if (Inventory1.Count > inventorySize)
            {
                Debug.Log("inventory is full");
            }
        }
        Debug.Log($"Inventory Size: {Inventory1.Count}");
       
    }
}
